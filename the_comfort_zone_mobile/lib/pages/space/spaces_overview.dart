import 'package:flutter/material.dart';
import 'package:provider/provider.dart';
import 'package:the_comfort_zone_mobile/model/space/space_response.dart';
import 'package:the_comfort_zone_mobile/pages/furniture_item/furniture_item_overview.dart';
import 'package:the_comfort_zone_mobile/providers/space_provider.dart';
import 'package:the_comfort_zone_mobile/utils/image_helper.dart';

class SpacesOverviewPage extends StatefulWidget {
  static const String routeName = "/spaces";

  const SpacesOverviewPage({Key? key}) : super(key: key);

  @override
  State<SpacesOverviewPage> createState() => _SpacesOverviewPageState();
}

class _SpacesOverviewPageState extends State<SpacesOverviewPage> {
  SpaceProvider? _spaceProvider = null;
  List<SpaceResponse> data = [];

  @override
  void initState() {
    super.initState();
    _spaceProvider = context.read<SpaceProvider>();
    loadData();
  }

  Future loadData() async {
    var apiData = await _spaceProvider?.getSpacesWithCategoryData();
    if (mounted) {
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
              child: Column(
        children: [
          Container(
            height: MediaQuery.of(context).size.height,
            width: MediaQuery.of(context).size.width,
            child: SafeArea(
              child: ListView(
                //padding: EdgeInsets.only(bottom: 150),
                children: _buildSpaceCardList(),
              ),
            ),
          )
        ],
      ))),
    ));
  }

  List<Widget> _buildSpaceCardList() {
    if (data.length == 0) {
      return [
        const Center(
            child: Text(
          "Loading...",
          style: TextStyle(
              color: Colors.grey, fontSize: 20, fontWeight: FontWeight.bold),
        )),
      ];
    }
    List<Widget> list = data
        .map((x) => Container(
            padding: const EdgeInsets.only(bottom: 10),
            width: double.infinity,
            child: Stack(
              alignment: Alignment.center,
              children: [
                Container(
                  child: imageFromBase64String(x.image!),
                ),
                Center(
                    child: Text(x.name!,
                        style: const TextStyle(
                            color: Colors.white,
                            fontSize: 25,
                            fontWeight: FontWeight.bold))),
                InkWell(
                  child: Container(
                    height: 100,
                    width: double.infinity,
                  ),
                  onTap: () async {
                    Navigator.of(context).push(MaterialPageRoute(
                        builder: (context) =>
                            FurnitureItemOverviewPage(x)));
                  },
                )
              ],
            )))
        .toList();

    return list;
  }
}
