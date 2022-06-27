import 'package:flutter/material.dart';
import 'package:intl/intl.dart';
import 'package:provider/provider.dart';
import 'package:the_comfort_zone_mobile/model/category/category_response.dart';
import 'package:the_comfort_zone_mobile/model/furniture_item/furniture_item_response.dart';
import 'package:the_comfort_zone_mobile/providers/category_provider.dart';
import 'package:the_comfort_zone_mobile/providers/furniture_item_provider.dart';
import 'package:the_comfort_zone_mobile/utils/image_helper.dart';

import '../../model/space/space_response.dart';

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

  _FurnitureItemOverviewPageState(this.space);

  @override
  void initState() {
    super.initState();
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
    Map<String, int> searchRequest = {"categoryId": categoryId};
    var apiData = await _productProvider?.get(searchRequest);
    if (mounted) {
      setState(() {
        data = apiData!;
      });
    }
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
        appBar: AppBar(
          iconTheme: const IconThemeData(color: Colors.black),
          title: Text(space.name!, style: TextStyle(color: Colors.black)),
          backgroundColor: Colors.grey[100],
          centerTitle: true,
          elevation: 0.0,
        ),
        body: SafeArea(
          child: SingleChildScrollView(
              child: Column(
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
              SizedBox(
                height: 10,
              ),
              Text("Categories", style: const TextStyle(fontSize: 18)),
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
                        child: SafeArea(
                          child: GridView(
                            physics: NeverScrollableScrollPhysics(),
                            gridDelegate:
                                const SliverGridDelegateWithFixedCrossAxisCount(
                                    crossAxisCount: 2,
                                    childAspectRatio: 3 / 6,
                                    crossAxisSpacing: 10,
                                    mainAxisSpacing: 10),
                            children: _buildFurnitureItemCardList(),
                          ),
                        ),
                      )
                    ],
                  ))
            ],
          )),
        ));
  }

  List<Widget> _buildFurnitureItemCardList() {
    if (data.length == 0) {
      return [];
    }
    List<Widget> list = data
        .map((x) => Container(
              width: double.infinity,
              decoration: BoxDecoration(
                borderRadius: BorderRadius.circular(10),
              ),
              child: Column(
                children: [
                  Container(
                    height: 270,
                    child: Column(
                      mainAxisAlignment: MainAxisAlignment.start,
                      children: [
                        imageFromBase64String(x.image!),
                      ],
                    ),
                  ),
                  Text(x.name ?? "",
                      style:
                          TextStyle(fontSize: 15, fontWeight: FontWeight.bold)),
                  Text("by ${x.designerName ?? ""}",
                      style: TextStyle(fontSize: 15, color: Colors.grey)),
                  Text(
                      "${formatter.format(x.onSale == true ? x.discountPrice : x.regularPrice)} KM",
                      style:
                          TextStyle(fontSize: 15, fontWeight: FontWeight.bold)),
                  Container(
                    alignment: Alignment.bottomRight,
                    padding: EdgeInsets.only(right: 15),
                    child: Icon(Icons.favorite_border, size: 30),
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
}
