import 'package:flutter/cupertino.dart';
import 'package:the_comfort_zone_mobile/model/cart/cart.dart';
import 'package:the_comfort_zone_mobile/model/furniture_item/furniture_item_response.dart';
import 'package:collection/collection.dart';

class CartProvider with ChangeNotifier {
  Cart cart = Cart();
  addToCart(FurnitureItemResponse furnitureItem) {
    if (findInCart(furnitureItem) != null) {
      findInCart(furnitureItem)?.count++;
    } else {
      cart.items.add(CartItem(furnitureItem, 1));
    }
    
    notifyListeners();
  }

  removeFromCart(FurnitureItemResponse furnitureItem) {
    cart.items.removeWhere((item) => item.furnitureItem.furnitureItemId == furnitureItem.furnitureItemId);
    notifyListeners();
  }

  CartItem? findInCart(FurnitureItemResponse furnitureItem) {
    CartItem? item = cart.items.firstWhereOrNull((item) => item.furnitureItem.furnitureItemId == furnitureItem.furnitureItemId);
    return item;
  }
}