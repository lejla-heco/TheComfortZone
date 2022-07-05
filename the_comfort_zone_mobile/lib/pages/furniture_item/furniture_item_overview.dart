import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:intl/intl.dart';
import 'package:provider/provider.dart';
import 'package:the_comfort_zone_mobile/model/category/category_response.dart';
import 'package:the_comfort_zone_mobile/model/furniture_item/furniture_item_response.dart';
import 'package:the_comfort_zone_mobile/pages/furniture_item/furniture_item_details.dart';
import 'package:the_comfort_zone_mobile/providers/category_provider.dart';
import 'package:the_comfort_zone_mobile/providers/furniture_item_provider.dart';
import 'package:the_comfort_zone_mobile/utils/image_helper.dart';

import '../../model/space/space_response.dart';
import '../../widgets/alert_dialog_widget.dart';

class FurnitureItemOverviewPage extends StatefulWidget {
  static const String routeName = "/furniture-items";
  final SpaceResponse space;

  const FurnitureItemOverviewPage(this.space, {Key? key}) : super(key: key);

  @override
  State<FurnitureItemOverviewPage> createState() =>
      _FurnitureItemOverviewPageState(this.space);
}

class _FurnitureItemOverviewPageState extends State<FurnitureItemOverviewPage> {
  FurnitureItemProvider? _productProvider = null;
  CategoryProvider? _categoryProvider = null;

  List<FurnitureItemResponse> data = [];
  List<CategoryResponse> categories = [];

  var formatter = NumberFormat('###.0#');
  final SpaceResponse space;
  int? selectedValue;

  late ScrollController _scrollController;

  _FurnitureItemOverviewPageState(this.space);

  @override
  void initState() {
    super.initState();
    _scrollController = ScrollController();
    _productProvider = context.read<FurnitureItemProvider>();
    _categoryProvider = context.read<CategoryProvider>();
    loadCategories();
  }

  Future loadCategories() async {
    var apiData =
        await _categoryProvider?.getCategoriesBySpaceId(space.spaceId!);
    if (mounted) {
      setState(() {
        categories = apiData!;
        selectedValue = categories[0].categoryId;
        loadData(selectedValue!);
      });
    }
  }

  Future loadData(int categoryId) async {
    Map<String, String> searchRequest = {
      "categoryId": categoryId.toString(),
      "state": "Active"
    };
    var apiData =
        await _productProvider?.getFurnitureItemsUserData(searchRequest);
    if (mounted) {
      setState(() {
        data = apiData!;
      });
    }
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      backgroundColor: Colors.grey[100],
      appBar: AppBar(
        iconTheme: const IconThemeData(color: Colors.white),
        title: Text(space.name!, style: TextStyle(color: Colors.white)),
        backgroundColor: Colors.black,
        centerTitle: true,
        elevation: 0.0,
      ),
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
                      child: imageFromBase64String(space.image!),
                    ),
                    Center(
                        child: Text(space.name!,
                            style: const TextStyle(
                                color: Colors.white,
                                fontSize: 25,
                                fontWeight: FontWeight.bold)))
                  ]),
                  const SizedBox(
                    height: 10,
                  ),
                  const Text("Categories",
                      style: const TextStyle(fontSize: 18)),
                  DropdownButton(
                      items: _buildCategoriesDropDownList(),
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
                      padding: EdgeInsets.only(left: 8, right: 8),
                      child: Column(
                        children: [
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
                        ],
                      ))
                ],
              ),
            ],
          ),
        ),
      ),
    );
  }

  double setChildAspectRatio() {
    if (data.length == 0) return 1;
    return 2.9 / 6;
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
          "Empty category",
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
                  Text("by ${x.designerName ?? ""}",
                      style: const TextStyle(fontSize: 15, color: Colors.grey)),
                  Text(
                      "${formatter.format(x.onSale == true ? x.discountPrice : x.regularPrice)} KM",
                      style: const TextStyle(
                          fontSize: 15, fontWeight: FontWeight.bold)),
                  TextButton.icon(
                    label: _defineLabel(
                        x.favourited == null ? false : x.favourited!),
                    icon: _defineIcon(
                        x.favourited == null ? false : x.favourited!),
                    onPressed: () async {
                      if (x.favourited == null ? false : x.favourited!) {
                        showDialog(
                            context: context,
                            builder: (BuildContext context) =>
                                AlertDialogWidget(
                                  title: "Warning",
                                  message: "Item is already in Favourites!",
                                  context: context,
                                ));
                      } else {
                        try {
                          var response = await _productProvider
                              ?.likeFurnitureItem(x.furnitureItemId!);
                          showDialog(
                              context: context,
                              builder: (BuildContext context) =>
                                  AlertDialogWidget(
                                    title: "Success",
                                    message: response.toString(),
                                    context: context,
                                  ));
                          await loadData(selectedValue!);
                        } catch (e) {
                          showDialog(
                              context: context,
                              builder: (BuildContext context) =>
                                  AlertDialogWidget(
                                    title: "Error",
                                    message: "An error occured!",
                                    context: context,
                                  ));
                        }
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

  List<DropdownMenuItem> _buildCategoriesDropDownList() {
    if (categories.length == 0) {
      return [];
    }
    List<DropdownMenuItem> list = categories
        .map((x) => DropdownMenuItem(
              child: Text(x.name!, style: TextStyle(color: Colors.black)),
              value: x.categoryId,
            ))
        .toList();
    return list;
  }

  Text _defineLabel(bool isFavourite) {
    const Text notFavorite = Text(
      "Like",
      style: TextStyle(color: Colors.black),
    );
    const Text favorite = Text(
      "Liked",
      style: TextStyle(color: Colors.black),
    );
    return isFavourite == true ? favorite : notFavorite;
  }

  Icon _defineIcon(bool isFavourite) {
    Icon notFavorite =
        const Icon(Icons.favorite_border, size: 30, color: Colors.black);
    Icon favorite = const Icon(Icons.favorite, size: 30, color: Colors.black);
    return isFavourite == true ? favorite : notFavorite;
  }
}
