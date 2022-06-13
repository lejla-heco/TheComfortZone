import 'package:flutter/material.dart';

class OrdersOverviewPage extends StatefulWidget {
  const OrdersOverviewPage({Key? key}) : super(key: key);

  @override
  State<OrdersOverviewPage> createState() => _MyWidgetState();
}

class _MyWidgetState extends State<OrdersOverviewPage> {
  @override
  Widget build(BuildContext context) {
    return const Scaffold(body: Center(child: Text("Orders"),));
  }
}