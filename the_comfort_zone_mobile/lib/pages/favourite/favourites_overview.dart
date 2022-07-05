import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:intl/intl.dart';
import 'package:provider/provider.dart';
import 'package:the_comfort_zone_mobile/model/space/space_response.dart';
import 'package:the_comfort_zone_mobile/providers/space_provider.dart';

import '../../model/furniture_item/furniture_item_response.dart';
import '../../providers/furniture_item_provider.dart';
import '../../utils/image_helper.dart';
import '../../widgets/alert_dialog_widget.dart';
import '../furniture_item/furniture_item_details.dart';

class FavouritesOverviewPage extends StatefulWidget {
  const FavouritesOverviewPage({Key? key}) : super(key: key);

  @override
  State<FavouritesOverviewPage> createState() => _FavouritesOverviewPageState();
}

class _FavouritesOverviewPageState extends State<FavouritesOverviewPage> {
  FurnitureItemProvider? _productProvider = null;
  SpaceProvider? _spaceProvider = null;

  List<FurnitureItemResponse> data = [];
  List<SpaceResponse> spaces = [];

  var formatter = NumberFormat('###.0#');
  int? selectedValue;

  bool _showBackToTopButton = false;
  late ScrollController _scrollController;

  @override
  void initState() {
    super.initState();

  _scrollController = ScrollController()
      ..addListener(() {
        setState(() {
          if (_scrollController.offset >= 10) {
            _showBackToTopButton = true;
          } else {
            _showBackToTopButton = false;
          }
        });
      });

    _productProvider = context.read<FurnitureItemProvider>();
    _spaceProvider = context.read<SpaceProvider>();
    loadSpaces();
  }

  Future loadSpaces() async {
    var apiData = await _spaceProvider?.getSpacesWithCategoryData();
    if (mounted) {
      setState(() {
        spaces = apiData!;
        selectedValue = spaces[0].spaceId;
        loadData(selectedValue!);
      });
    }
  }

  Future loadData(int spaceId) async {
    Map<String, String> searchRequest = {
      "spaceId": spaceId.toString(),
      "state": "Active"
    };
    var apiData = await _productProvider?.getFavourites(searchRequest);
    if (mounted) {
      setState(() {
        data = apiData!;
      });
    }
  }

  @override
  void dispose() {
    _scrollController.dispose();
    super.dispose();
  }

  void _scrollToTop() {
    _scrollController.animateTo(0,
        duration: const Duration(milliseconds: 200), curve: Curves.linear);
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      backgroundColor: Colors.grey[100],
      body: SafeArea(
        child: CupertinoScrollbar(
          thumbVisibility: true,
          thickness: 5,
          controller: _scrollController,
          child: ListView(
            controller: _scrollController,
            children: [
              Column(
                children: [
                  Stack(alignment: Alignment.center, children: [
                    Container(
                        height: 150,
                        decoration: const BoxDecoration(
                            image: DecorationImage(
                          image: AssetImage("assets/images/wishlist-bg.jpg"),
                          fit: BoxFit.fill,
                        ))),
                    const Center(
                        child: Text("Your wishlist",
                            style: TextStyle(
                                color: Colors.white,
                                fontSize: 25,
                                fontWeight: FontWeight.bold)))
                  ]),
                  const SizedBox(
                    height: 10,
                  ),
                  const Text("Spaces", style: const TextStyle(fontSize: 18)),
                  DropdownButton(
                      items: _buildSpacesDropDownList(),
                      value: selectedValue,
                      onChanged: (dynamic newValue) {
                        if (mounted) {
                          setState(() {
                            selectedValue = newValue;
                            loadData(newValue);
                          });
                        }
                      }),
                  Container(
                      padding: const EdgeInsets.only(left: 8, right: 8),
                      child: Column(children: [
                        Container(
                          height: MediaQuery.of(context).size.height,
                          width: MediaQuery.of(context).size.width,
                          child: GridView(
                            controller: ScrollController(),
                            gridDelegate:
                                SliverGridDelegateWithFixedCrossAxisCount(
                                    crossAxisCount: setCrossAxisCount(),
                                    childAspectRatio: setChildAspectRatio(),
                                    crossAxisSpacing: 10,
                                    mainAxisSpacing: 10),
                            children: _buildFurnitureItemCardList(),
                          ),
                        ),
                      ]))
                ],
              ),
            ],
          ),
        ),
      ),
      floatingActionButton: _showBackToTopButton == false
          ? null
          : FloatingActionButton(
              onPressed: _scrollToTop,
              child: const Icon(Icons.arrow_upward),
              tooltip: 'Back to top!',
              backgroundColor: Colors.black,
            ),
    );
  }

  List<DropdownMenuItem> _buildSpacesDropDownList() {
    if (spaces.length == 0) {
      return [];
    }
    List<DropdownMenuItem> list = spaces
        .map((x) => DropdownMenuItem(
              child: Text(x.name!, style: TextStyle(color: Colors.black)),
              value: x.spaceId,
            ))
        .toList();
    return list;
  }

  double setChildAspectRatio() {
    if (data.length == 0) return 1;
    return 3 / 6;
  }

  int setCrossAxisCount() {
    if (data.length == 0) return 1;
    return 2;
  }

  List<Widget> _buildFurnitureItemCardList() {
    if (data.length == 0) {
      return [
        const Center(
            child: Text(
          "You don't have favourites",
          style: TextStyle(
              color: Colors.grey, fontSize: 25, fontWeight: FontWeight.bold),
        )),
      ];
    }
    List<Widget> list = data
        .map((x) => Container(
              width: double.infinity,
              decoration: BoxDecoration(
                borderRadius: BorderRadius.circular(10),
                color: Colors.white,
              ),
              child: Column(
                children: [
                  GestureDetector(
                    child: Container(
                      height: 270,
                      child: Column(
                        mainAxisAlignment: MainAxisAlignment.start,
                        children: [
                          imageFromBase64String(x.image!),
                        ],
                      ),
                    ),
                    onTap: () {
                      Navigator.of(context).push(MaterialPageRoute(
                          builder: (context) => FurnitureItemDetailsPage(x)));
                    },
                  ),
                  const SizedBox(height: 5),
                  Text(x.name ?? "",
                      style: const TextStyle(
                          fontSize: 15, fontWeight: FontWeight.bold)),
                  Text(x.categoryName ?? "",
                      style: const TextStyle(fontSize: 15, color: Colors.grey)),
                  Text(
                      "${formatter.format(x.onSale == true ? x.discountPrice : x.regularPrice)} KM",
                      style: const TextStyle(
                          fontSize: 15, fontWeight: FontWeight.bold)),
                  TextButton.icon(
                    label: const Text("Remove", style: TextStyle(color: Colors.black),),
                    icon: const Icon(Icons.delete_outline_rounded, size: 30, color: Colors.black),
                    onPressed: () async {
                      try {
                        showDialog(
                            context: context,
                            builder: (BuildContext dialogContex) =>
                                AlertDialog(
                                  title: const Text("Warning"),
                                  content: const Text(
                                      "Are you sure you want to remove this item from Favourites?"),
                                  actions: [
                                    TextButton(
                                        onPressed: () async {
                                          Navigator.pop(dialogContex);
                                          var response =
                                              await _productProvider
                                                  ?.dislikeFurnitureItem(
                                                      x.furnitureItemId!);
                                          showDialog(
                                              context: context,
                                              builder: (BuildContext
                                                      dialogContex) =>
                                                  AlertDialogWidget(
                                                    title: "Success",
                                                    message:
                                                        response.toString(),
                                                    context: context,
                                                  ));
                                          await loadData(selectedValue!);
                                        },
                                        child: const Text("Yes")),
                                    TextButton(
                                      onPressed: () =>
                                          Navigator.pop(dialogContex),
                                      child: const Text("No"),
                                    )
                                  ],
                                ));
                      } catch (e) {
                        showDialog(
                            context: context,
                            builder: (BuildContext dialogContex) =>
                                AlertDialogWidget(
                                  title: "Error",
                                  message: "An error occured!",
                                  context: dialogContex,
                                ));
                      }
                    },
                  )
                ],
              ),
            ))
        .cast<Widget>()
        .toList();

    return list;
  }
}
