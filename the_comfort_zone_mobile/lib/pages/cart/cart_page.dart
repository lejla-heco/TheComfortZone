import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';
import 'package:the_comfort_zone_mobile/model/coupon/coupon_response.dart';
import 'package:the_comfort_zone_mobile/providers/cart_provider.dart';
import 'package:the_comfort_zone_mobile/providers/coupon_provider.dart';
import 'package:the_comfort_zone_mobile/utils/image_helper.dart';
import 'package:the_comfort_zone_mobile/widgets/alert_dialog_widget.dart';

import '../../providers/order_provider.dart';
import '../../utils/logged_in_user.dart';

class CartPage extends StatefulWidget {
  static const String routeName = "/cart";

  const CartPage({Key? key}) : super(key: key);

  @override
  State<CartPage> createState() => _CartPageState();
}

class _CartPageState extends State<CartPage> {
  ScrollController? _scrollController = null;
  CouponProvider? _couponProvider = null;
  OrderProvider? _orderProvider = null;
  late CartProvider _cartProvider;

  int? selectedValue;
  List<CouponResponse> coupons = [];

  @override
  void initState() {
    _scrollController = ScrollController();
    _couponProvider = context.read<CouponProvider>();
    _orderProvider = context.read<OrderProvider>();
    loadCoupons();
    super.initState();
  }

  @override
  void didChangeDependencies() {
    _cartProvider = context.watch<CartProvider>();
    super.didChangeDependencies();
  }

  Future loadCoupons() async {
    var apiData = await _couponProvider?.getCouponsByUserId();
    if (mounted) {
      setState(() {
        coupons = apiData!;
      });
    }
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      backgroundColor: Colors.grey[100],
      appBar: AppBar(
        iconTheme: const IconThemeData(color: Colors.white),
        title: const Text("My Cart", style: TextStyle(color: Colors.white)),
        backgroundColor: Colors.black,
        centerTitle: true,
        elevation: 0.0,
      ),
      body: SafeArea(
        child: CupertinoScrollbar(
          thumbVisibility: true,
          thickness: 5,
          controller: _scrollController,
          child: ListView(controller: _scrollController, children: [
            Container(
              padding: const EdgeInsets.only(top: 10),
              child: const Center(
                  child: Text(
                "Your products",
                style: TextStyle(fontSize: 20, fontWeight: FontWeight.bold),
              )),
            ),
            _buildCouponRow(),
            Center(
                child: Text(
              "Total price: ${_cartProvider.totalPrice} KM",
              style: const TextStyle(fontSize: 16, fontWeight: FontWeight.bold),
            )),
            _buildCartContainer(),
          ]),
        ),
      ),
      floatingActionButton: FloatingActionButton.extended(
        onPressed: () async {
          if (_cartProvider.cart.items.isEmpty) {
            showDialog(
                context: context,
                builder: (BuildContext dialogContex) => AlertDialogWidget(
                      title: "Message",
                      message: "Your cart is empty!",
                      context: dialogContex,
                    ));
          } else {
            List<Map> items = [];
            _cartProvider.cart.items.forEach((item) {
              items.add({
                "furnitureItemId": item.furnitureItem.furnitureItemId,
                "color": item.furnitureItem.color,
                "orderQuantity": item.count,
                "unitPrice": item.furnitureItem.onSale == true
                    ? item.furnitureItem.discountPrice!
                    : item.furnitureItem.regularPrice
              });
            });
            Map order = {
              "userId": LoggedInUser.userId,
              "couponId": selectedValue == 0 ? null : selectedValue,
              "items": items,
            };
            try{
            var response = await _orderProvider?.insert(order);
              _cartProvider.totalPrice = 0;
              _cartProvider.cart.items.clear();
              setState(() {});
              showDialog(
                  context: context,
                  builder: (BuildContext dialogContex) => AlertDialogWidget(
                        title: "Message",
                        message: "Your order is sent successfully!",
                        context: dialogContex,
                      ));
            }
            catch(e){
              showDialog(
                  context: context,
                  builder: (BuildContext dialogContex) => AlertDialogWidget(
                        title: "Error",
                        message: "An error occured!",
                        context: dialogContex,
                      ));
            }
          }
        },
        icon: const Icon(Icons.attach_money_rounded),
        tooltip: 'Send your order!',
        backgroundColor: Colors.black,
        label: const Text("Order"),
      ),
      floatingActionButtonLocation: FloatingActionButtonLocation.centerFloat,
    );
  }

  Container _buildCartContainer() {
    return Container(
        padding: EdgeInsets.all(8),
        child: Column(
          children: [
            Container(
              height: MediaQuery.of(context).size.height,
              width: MediaQuery.of(context).size.width,
              child: GridView(
                controller: ScrollController(),
                gridDelegate: SliverGridDelegateWithFixedCrossAxisCount(
                    crossAxisCount: setCrossAxisCount(),
                    childAspectRatio: setChildAspectRatio(),
                    crossAxisSpacing: 10,
                    mainAxisSpacing: 10),
                children: _buildCartItemCard(),
              ),
            ),
          ],
        ));
  }

  double setChildAspectRatio() {
    if (_cartProvider.cart.items.isEmpty) return 1;
    return 2.9 / 6;
  }

  int setCrossAxisCount() {
    if (_cartProvider.cart.items.isEmpty) return 1;
    return 2;
  }

  List<Widget> _buildCartItemCard() {
    if (_cartProvider.cart.items.isEmpty) {
      return [
        const Center(
            child: Text(
          "Empty cart",
          style: TextStyle(
              color: Colors.grey, fontSize: 25, fontWeight: FontWeight.bold),
        )),
      ];
    }
    List<Widget> list = _cartProvider.cart.items
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
                        imageFromBase64String(x.furnitureItem.image!),
                      ],
                    ),
                  )),
                  const SizedBox(height: 5),
                  Text(x.furnitureItem.name ?? "",
                      style: const TextStyle(
                          fontSize: 16, fontWeight: FontWeight.bold)),
                  Text(x.furnitureItem.color ?? "",
                      style: const TextStyle(fontSize: 15, color: Colors.grey)),
                  Text(
                      "${x.furnitureItem.onSale == true ? x.furnitureItem.discountPrice : x.furnitureItem.regularPrice} KM",
                      style: const TextStyle(
                          fontSize: 15, fontWeight: FontWeight.bold)),
                  Container(
                    child: Row(
                        mainAxisAlignment: MainAxisAlignment.center,
                        children: [
                          Row(
                            children: [
                              IconButton(
                                  icon: const Icon(
                                      Icons.remove_circle_outline_rounded,
                                      size: 22),
                                  onPressed: () {
                                    _cartProvider.removeFromCart(
                                        x.furnitureItem, false);
                                  }),
                              Text(
                                  "${_cartProvider.findInCart(x.furnitureItem)?.count}"),
                              IconButton(
                                  icon: const Icon(
                                      Icons.add_circle_outline_outlined,
                                      size: 22),
                                  onPressed: () {
                                    _cartProvider.addToCart(x.furnitureItem);
                                  }),
                            ],
                          ),
                          IconButton(
                              icon: const Icon(Icons.delete_outline_rounded,
                                  size: 22),
                              onPressed: () {
                                showDialog(
                                    context: context,
                                    builder: (BuildContext dialogContex) =>
                                        AlertDialog(
                                          title: const Text("Question"),
                                          content: const Text(
                                              "Are you sure you want to remove this item from cart?"),
                                          actions: [
                                            TextButton(
                                                onPressed: () {
                                                  Navigator.pop(dialogContex);
                                                  _cartProvider.removeFromCart(
                                                      x.furnitureItem, true);
                                                },
                                                child: const Text("Yes")),
                                            TextButton(
                                              onPressed: () =>
                                                  Navigator.pop(dialogContex),
                                              child: const Text("No"),
                                            )
                                          ],
                                        ));
                              })
                        ]),
                  ),
                ],
              ),
            ))
        .cast<Widget>()
        .toList();

    return list;
  }

  Row _buildCouponRow() {
    return Row(mainAxisAlignment: MainAxisAlignment.center, children: [
      const Text(
        "Discount coupon:",
        style: TextStyle(fontSize: 16),
      ),
      const SizedBox(
        width: 20,
      ),
      DropdownButton(
          items: _buildCouponsDropDownList(),
          value: selectedValue,
          onChanged: (int? newValue) {
            if (mounted) {
              setState(() {
                selectedValue = newValue;
              });
            }
          }),
    ]);
  }

  List<DropdownMenuItem<int>> _buildCouponsDropDownList() {
    if (coupons.isEmpty) {
      selectedValue = 0;
      return [
        const DropdownMenuItem(child: Text("No available coupons"), value: 0)
      ];
    }
    List<DropdownMenuItem<int>> list = coupons
        .map((x) => DropdownMenuItem(
              child: Text("${x.couponCode} - ${x.discount}%",
                  style: const TextStyle(color: Colors.black)),
              value: x.couponId,
            ))
        .toList();

    list.insert(
        0,
        const DropdownMenuItem(
            child: Text("Order without coupon",
                style: TextStyle(color: Colors.black)),
            value: 0));
    return list;
  }
}
