import 'package:flutter/material.dart';
import 'package:intl/intl.dart';
import 'package:provider/provider.dart';
import 'package:the_comfort_zone_mobile/model/furniture_item/furniture_item_response.dart';
import 'package:the_comfort_zone_mobile/providers/cart_provider.dart';
import 'package:the_comfort_zone_mobile/providers/furniture_item_provider.dart';
import 'package:the_comfort_zone_mobile/utils/image_helper.dart';

class FurnitureItemDetailsPage extends StatefulWidget {
  final FurnitureItemResponse item;
  const FurnitureItemDetailsPage(this.item, {Key? key}) : super(key: key);

  @override
  State<FurnitureItemDetailsPage> createState() =>
      _FurnitureItemDetailsPageState(item);
}

class _FurnitureItemDetailsPageState extends State<FurnitureItemDetailsPage> {
  CartProvider? _cartProvider = null;
  FurnitureItemProvider? _productProvider = null;
  final FurnitureItemResponse item;
  var formatter = NumberFormat('###.0#');
  int? selectedValue = 1;
  List<String> colors = [];
  List<FurnitureItemResponse> recommendedItems = [];

  _FurnitureItemDetailsPageState(this.item);

  @override
  void initState() {
    _cartProvider = context.read<CartProvider>();
    _productProvider = context.read<FurnitureItemProvider>();
    loadData();
    super.initState();
  }

  Future loadData() async {
    var apiData =
        await _productProvider?.getRecommendedItems(item.furnitureItemId!);
    if (mounted) {
      setState(() {
        recommendedItems = apiData!;
      });
    }
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
        backgroundColor: Colors.grey[100],
        appBar: AppBar(
          iconTheme: const IconThemeData(color: Colors.white),
          title: Text(item.name!, style: const TextStyle(color: Colors.white)),
          backgroundColor: Colors.black,
          centerTitle: true,
          elevation: 0.0,
        ),
        body: SafeArea(
          child: SingleChildScrollView(
              child: Column(
            crossAxisAlignment: CrossAxisAlignment.start,
            children: [
              Container(child: imageFromBase64String(item.image!)),
              const SizedBox(
                height: 10,
              ),
              _buildFurnitureItemInformation(),
              const SizedBox(
                height: 10,
              ),
              _buildFurnitureItemDescriptionContainer(),
              const Center(child: Text("Recommended products", style: TextStyle(fontWeight: FontWeight.bold, fontSize: 16),)),
              const SizedBox(height: 5),
              _buildRecommendedProductInformation(),
            ],
          )),
        ));
  }

  Column _buildFurnitureItemInformation() {
    return Column(
      children: [
        Text(
          "${item.collectionName} by ${item.designerName}",
          style: const TextStyle(fontSize: 15, color: Colors.grey),
        ),
        const SizedBox(
          height: 6,
        ),
        Text(
          item.categoryName!,
          style: const TextStyle(fontSize: 15, color: Colors.grey),
        ),
        const SizedBox(
          height: 6,
        ),
        Text(
          item.name!,
          style: const TextStyle(fontSize: 22, fontWeight: FontWeight.bold),
        ),
        const SizedBox(
          height: 2,
        ),
        Text(
          "${formatter.format(item.onSale == true ? item.discountPrice : item.regularPrice)} KM",
          style: const TextStyle(fontSize: 20, fontWeight: FontWeight.bold),
        ),
        Row(
          mainAxisAlignment: MainAxisAlignment.center,
          children: [
            const Text("Color:", style: TextStyle(fontSize: 16)),
            const SizedBox(
              width: 20,
            ),
            DropdownButton(
                items: _buildColorsList(),
                value: selectedValue,
                onChanged: (dynamic newValue) {
                  if (mounted) {
                    setState(() {
                      selectedValue = newValue;
                    });
                  }
                }),
          ],
        ),
        Text("Dimensions: ${item.dimensions}",
            style: const TextStyle(fontSize: 16)),
        const SizedBox(
          height: 6,
        ),
        Text("Material: ${item.material}",
            style: const TextStyle(fontSize: 16)),
        const SizedBox(
          height: 6,
        ),
        ElevatedButton.icon(
            onPressed: () {
              FurnitureItemResponse newItem = FurnitureItemResponse.fromItem(
                  item.furnitureItemId,
                  item.name,
                  item.image,
                  item.onSale,
                  item.regularPrice,
                  item.discountPrice);
              newItem.color = colors[selectedValue! - 1];
              _cartProvider?.addToCart(newItem);
            },
            icon: const Icon(
              Icons.shopping_cart_checkout_rounded,
              size: 28,
            ),
            label: const Text('Add to cart'),
            style: ElevatedButton.styleFrom(
                primary: Colors.black,
                textStyle:
                    const TextStyle(fontSize: 15, fontWeight: FontWeight.bold)))
      ],
    );
  }

  Container _buildRecommendedProductInformation() {
    return Container(
        padding: const EdgeInsets.only(left: 10, right: 10),
        child: Column(children: [
          Container(
            height: 370,
            width: MediaQuery.of(context).size.width,
            child: GridView(
              scrollDirection: Axis.horizontal,
              gridDelegate: const SliverGridDelegateWithFixedCrossAxisCount(
                  crossAxisCount: 1,
                  childAspectRatio: 3.6 / 2,
                  crossAxisSpacing: 10,
                  mainAxisSpacing: 10),
              children: _buildFurnitureItemCardList(),
            ),
          )
        ]));
  }

  Container _buildFurnitureItemDescriptionContainer() {
    return Container(
      padding: const EdgeInsets.only(left: 7, right: 7, bottom: 10),
      child: Column(
        crossAxisAlignment: CrossAxisAlignment.start,
        children: [
          const Text(
            "Product description:",
            style: TextStyle(fontSize: 16),
            textAlign: TextAlign.left,
          ),
          Text(
            item.description!,
            style: const TextStyle(fontSize: 16),
            textAlign: TextAlign.left,
          ),
        ],
      ),
    );
  }

  List<DropdownMenuItem> _buildColorsList() {
    var substrings = item.colors!.split(',');
    colors = substrings;
    var startValue = 1;
    List<DropdownMenuItem> list = substrings
        .map((x) => DropdownMenuItem(
            child: Text(x, style: const TextStyle(color: Colors.black)),
            value: startValue++))
        .toList();
    return list;
  }

  List<Widget> _buildFurnitureItemCardList() {
    if (recommendedItems.isEmpty) {
      return [
        const Center(
            child: Text(
          "Loading...",
          style: TextStyle(
              color: Colors.grey, fontSize: 20, fontWeight: FontWeight.bold),
        )),
      ];
    }
    List<Widget> list = recommendedItems
        .map((x) => Container(
              width: double.infinity,
              decoration: BoxDecoration(
                borderRadius: BorderRadius.circular(10),
                color: Colors.white,
              ),
              child: Column(
                children: [
                  Container(
                    height: 280,
                    child: Column(
                      mainAxisAlignment: MainAxisAlignment.start,
                      children: [
                        imageFromBase64String(x.image!),
                      ],
                    ),
                  ),
                  Text(x.name ?? "",
                      style: const TextStyle(
                          fontSize: 15, fontWeight: FontWeight.bold)),
                  Text(
                      "${formatter.format(x.onSale == true ? x.discountPrice : x.regularPrice)} KM",
                      style: const TextStyle(
                          fontSize: 15, fontWeight: FontWeight.bold)),
                  TextButton.icon(
                    label: const Text(
                      "View details",
                      style: TextStyle(color: Colors.black),
                    ),
                    icon: const Icon(Icons.search_rounded,
                        size: 30, color: Colors.black),
                    onPressed: () {
                      Navigator.of(context).push(MaterialPageRoute(
                          builder: (context) => FurnitureItemDetailsPage(x)));
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
