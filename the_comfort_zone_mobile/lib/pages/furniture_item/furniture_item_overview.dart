import 'package:flutter/material.dart';
import 'package:provider/provider.dart';
import 'package:the_comfort_zone_mobile/model/furniture_item/furniture_item_response.dart';
import 'package:the_comfort_zone_mobile/providers/furniture_item_provider.dart';
import 'package:the_comfort_zone_mobile/utils/image_helper.dart';

class FurnitureItemOverviewPage extends StatefulWidget {
  static const String routeName = "/furniture-items";
  const FurnitureItemOverviewPage({Key? key}) : super(key: key);

  @override
  State<FurnitureItemOverviewPage> createState() => _FurnitureItemOverviewPageState();
}

class _FurnitureItemOverviewPageState extends State<FurnitureItemOverviewPage> {

  FurnitureItemProvider? _productProvider = null;
  List<FurnitureItemResponse> data = [];

  @override
  void initState() {
    super.initState();
    _productProvider = context.read<FurnitureItemProvider>();
    loadData();
  }

  Future loadData() async {
    var apiData = await _productProvider?.get(null);
    if (mounted){
    setState(() {
      data = apiData!;
    });
    }
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: SafeArea(
        child: SingleChildScrollView(
          child: Container(
            child: Column(children: [
              Container(
                height: MediaQuery.of(context).size.height,
                width: MediaQuery.of(context).size.width,
                child: GridView(
                  gridDelegate: SliverGridDelegateWithFixedCrossAxisCount(
                    crossAxisCount: 2, 
                    childAspectRatio: 4 / 3,
                    crossAxisSpacing: 10,
                    mainAxisSpacing: 20
                    ),
                    scrollDirection: Axis.vertical,
                    children: _buildFurnitureItemCardList(),
                ),
              )
            ],)
          )
        ),
      )
    );
  }

  List<Widget> _buildFurnitureItemCardList(){
    if (data.length == 0){
      return [Text("Loading...")];
    }
    List<Widget> list = data.map((x) => Container(
      height: 200,
      width: 200,
      child: Column(children: [
        Container(
          height: 100,
          child: imageFromBase64String(x.image!),),
        Text(x.name ?? "")
      ],),
    )).cast<Widget>().toList();

    return list;
  }
}