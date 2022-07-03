import 'package:the_comfort_zone_mobile/model/furniture_item/furniture_item_response.dart';

class Cart {
    List<CartItem> items = [];
}

class CartItem {
  CartItem(this.furnitureItem, this.count);
  late FurnitureItemResponse furnitureItem;
  late int count;
}