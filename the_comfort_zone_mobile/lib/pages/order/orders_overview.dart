import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:flutter_datetime_picker/flutter_datetime_picker.dart';
import 'package:intl/intl.dart';
import 'package:provider/provider.dart';
import 'package:the_comfort_zone_mobile/providers/order_provider.dart';
import 'package:the_comfort_zone_mobile/widgets/alert_dialog_widget.dart';

import '../../model/order/order_response.dart';

class OrdersOverviewPage extends StatefulWidget {
  const OrdersOverviewPage({Key? key}) : super(key: key);

  @override
  State<OrdersOverviewPage> createState() => _MyWidgetState();
}

class _MyWidgetState extends State<OrdersOverviewPage> {
  ScrollController? _scrollController;

  OrderProvider? _orderProvider = null;
  List<OrderResponse> data = [];
  var formatter = NumberFormat('###.0#');

  @override
  void initState() {
    _scrollController = ScrollController();
    _orderProvider = context.read<OrderProvider>();
    loadData(null);
    super.initState();
  }

  Future loadData(DateTime? orderDate) async {
    Map<String, String>? searchRequest = orderDate == null
        ? null
        : {
            "orderDate": orderDate.toString(),
          };

    var apiData = await _orderProvider?.getOrdersByUserId(searchRequest);
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
                        height: 200,
                        decoration: const BoxDecoration(
                            image: DecorationImage(
                          image: AssetImage("assets/images/orders-bg.png"),
                          fit: BoxFit.fill,
                        ))),
                    const Center(
                        child: Text("My orders",
                            style: TextStyle(
                                color: Colors.white,
                                fontSize: 25,
                                fontWeight: FontWeight.bold)))
                  ]),
                  const SizedBox(
                    height: 10,
                  ),
                ],
              ),
              TextButton(
                  onPressed: () {
                    DatePicker.showDatePicker(context,
                        showTitleActions: true,
                        minTime: DateTime(2000, 1, 1),
                        maxTime: DateTime(2050, 1, 1), onCancel: () {
                      showDialog(
                          context: context,
                          builder: (BuildContext dialogContex) => AlertDialog(
                                title: const Text("Question"),
                                content: const Text(
                                    "Do you want to realod order data?"),
                                actions: [
                                  TextButton(
                                      onPressed: () async {
                                        Navigator.pop(dialogContex);
                                        await loadData(null);
                                      },
                                      child: const Text("Yes")),
                                  TextButton(
                                    onPressed: () =>
                                        Navigator.pop(dialogContex),
                                    child: const Text("No"),
                                  )
                                ],
                              ));
                    }, onConfirm: (date) async {
                      try {
                        var apiData = await loadData(date);
                        setState(() {
                          data = apiData;
                        });
                      } catch (e) {showDialog(
                              context: context,
                              builder: (BuildContext dialogContex) =>
                                  AlertDialogWidget(
                                    title: "Error",
                                    message: "You don't have any orders!",
                                    context: dialogContex,
                                  ));
                      }
                    }, currentTime: DateTime.now(), locale: LocaleType.en);
                  },
                  child: const Text(
                    'Show date time picker (click here)',
                    style: TextStyle(color: Colors.blue),
                  )),
              Column(
                crossAxisAlignment: CrossAxisAlignment.start,
                children: _buildOrderCards(),
              )
            ],
          ),
        ),
      ),
    );
  }

  List<Widget> _buildOrderCards() {
    if (data.length == 0) {
      return [
        const SizedBox(height: 100,),
        const Center(
            child: Text(
          "You don't have any orders",
          style: TextStyle(
              color: Colors.grey, fontSize: 25, fontWeight: FontWeight.bold),
        )),
      ];
    }

    List<Column> list = data
        .map((x) => Column(
              children: [
                Container(
                    padding: EdgeInsets.all(8),
                    decoration: BoxDecoration(color: Colors.grey.shade200),
                    width: MediaQuery.of(context).size.width,
                    child: Column(
                      crossAxisAlignment: CrossAxisAlignment.start,
                      children: [
                        Text("Order number: ${x.orderNumber}",
                            style: const TextStyle(
                                color: Colors.black,
                                fontSize: 17,
                                fontWeight: FontWeight.bold)),
                        Text(
                            "Order date: ${DateFormat.yMMMEd().format(x.orderDate!)}",
                            style: const TextStyle(
                                color: Colors.black, fontSize: 15)),
                        Text("Number of items purchased: ${x.noip}",
                            style: const TextStyle(
                                color: Colors.black, fontSize: 15)),
                        Text("Order status: ${x.status!.toUpperCase()}",
                            style: const TextStyle(
                                color: Colors.black, fontSize: 15)),
                        Align(
                          alignment: Alignment.bottomRight,
                          child: Text(
                            "Total price: ${formatter.format(x.totalPrice)} KM",
                            style: const TextStyle(
                                color: Colors.black,
                                fontSize: 16,
                                fontWeight: FontWeight.bold),
                          ),
                        ),
                      ],
                    )),
                const SizedBox(
                  height: 10,
                )
              ],
            ))
        .toList();
    return list;
  }
}
