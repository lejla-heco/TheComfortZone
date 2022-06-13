import 'package:flutter/material.dart';

class FavouritesOverviewPage extends StatefulWidget {
  const FavouritesOverviewPage({Key? key}) : super(key: key);

  @override
  State<FavouritesOverviewPage> createState() => _MyWidgetState();
}

class _MyWidgetState extends State<FavouritesOverviewPage> {
  @override
  Widget build(BuildContext context) {
    return const Scaffold(body: Center(child: Text("Favourites"),));
  }
}