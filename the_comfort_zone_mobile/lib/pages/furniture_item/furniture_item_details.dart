import 'package:flutter/material.dart';
import 'package:intl/intl.dart';
import 'package:the_comfort_zone_mobile/model/furniture_item/furniture_item_response.dart';
import 'package:the_comfort_zone_mobile/utils/image_helper.dart';

class FurnitureItemDetailsPage extends StatefulWidget {
  final FurnitureItemResponse item;
  const FurnitureItemDetailsPage(this.item, {Key? key}) : super(key: key);

  @override
  State<FurnitureItemDetailsPage> createState() =>
      _FurnitureItemDetailsPageState(this.item);
}

class _FurnitureItemDetailsPageState extends State<FurnitureItemDetailsPage> {
  final FurnitureItemResponse item;
  var formatter = NumberFormat('###.0#');
  int? selectedValue = 1;

  _FurnitureItemDetailsPageState(this.item);

  @override
  Widget build(BuildContext context) {
    return Scaffold(
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
              Column(
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
                    style: const TextStyle(
                        fontSize: 22, fontWeight: FontWeight.bold),
                  ),
                  const SizedBox(
                    height: 2,
                  ),
                  Text(
                    "${formatter.format(item.onSale == true ? item.discountPrice : item.regularPrice)} KM",
                    style: const TextStyle(
                        fontSize: 20, fontWeight: FontWeight.bold),
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
                        print("added to cart");
                      },
                      icon: const Icon(
                        Icons.shopping_cart_checkout_rounded,
                        size: 28,
                      ),
                      label: const Text('Add to cart'),
                      style: ElevatedButton.styleFrom(
                        primary: Colors.black,
                        textStyle: const TextStyle(fontSize: 15, fontWeight: FontWeight.bold)
                      ))
                ],
              ),
              const SizedBox(
                height: 10,
              ),
              Container(
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
              ),
            ],
          )),
        ));
  }

  List<DropdownMenuItem> _buildColorsList() {
    var substrings = item.colors!.split(',');
    var startValue = 1;
    List<DropdownMenuItem> list = substrings
        .map((x) => DropdownMenuItem(
            child: Text(x, style: const TextStyle(color: Colors.black)),
            value: startValue++))
        .toList();
    return list;
  }
}
