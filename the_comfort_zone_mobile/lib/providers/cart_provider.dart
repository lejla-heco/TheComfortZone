import 'package:flutter/cupertino.dart';
import 'package:the_comfort_zone_mobile/model/cart/cart.dart';
import 'package:the_comfort_zone_mobile/model/furniture_item/furniture_item_response.dart';
import 'package:collection/collection.dart';

class CartProvider with ChangeNotifier {
  Cart cart = Cart();
  double totalPrice = 0;
  addToCart(FurnitureItemResponse furnitureItem) {
    if (findInCart(furnitureItem) != null) {
      findInCart(furnitureItem)?.count++;
    } else {
      cart.items.add(CartItem(furnitureItem, 1));
    }
    furnitureItem.onSale == true
        ? totalPrice += furnitureItem.discountPrice!
        : totalPrice += furnitureItem.regularPrice!;

    notifyListeners();
  }

  removeFromCart(FurnitureItemResponse furnitureItem, bool isDelete) {
    if (findInCart(furnitureItem)!.count == 1 || isDelete) {

      totalPrice -= furnitureItem.onSale == true
          ? furnitureItem.discountPrice! *
              cart.items
                  .firstWhere((item) =>
                      item.furnitureItem.furnitureItemId ==
                          furnitureItem.furnitureItemId &&
                      item.furnitureItem.color == furnitureItem.color)
                  .count
          : furnitureItem.regularPrice! *
              cart.items
                  .firstWhere((item) =>
                      item.furnitureItem.furnitureItemId ==
                          furnitureItem.furnitureItemId &&
                      item.furnitureItem.color == furnitureItem.color)
                  .count;

      cart.items.removeWhere((item) =>
          item.furnitureItem.furnitureItemId == furnitureItem.furnitureItemId &&
          item.furnitureItem.color == furnitureItem.color);
      
    } else {
      totalPrice -= furnitureItem.onSale == true
          ? furnitureItem.discountPrice!
          : furnitureItem.regularPrice!;
      findInCart(furnitureItem)?.count--;
    }
    notifyListeners();
  }

  CartItem? findInCart(FurnitureItemResponse furnitureItem) {
    CartItem? item = cart.items.firstWhereOrNull((item) =>
        item.furnitureItem.furnitureItemId == furnitureItem.furnitureItemId &&
        item.furnitureItem.color == furnitureItem.color);
    return item;
  }
}
