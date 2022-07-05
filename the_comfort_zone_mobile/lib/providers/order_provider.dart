import 'dart:convert';

import 'package:the_comfort_zone_mobile/model/order/order_response.dart';
import 'package:the_comfort_zone_mobile/providers/base_provider.dart';

import '../utils/logged_in_user.dart';

class OrderProvider extends BaseProvider<OrderResponse>{
  static const String apiRoute = "Order";
  OrderProvider() : super(apiRoute);

  @override
  OrderResponse fromJson(data) {
    return OrderResponse.fromJson(data);
  }

  Future<List<OrderResponse>> getOrdersByUserId([dynamic search]) async {
    var url = "$publicUrl/orders-by-user/${LoggedInUser.userId}";

    if (search != null) {
      String queryString = getQueryString(search);
      url = url + "?" + queryString;
    }

    var uri = Uri.parse(url);

    Map<String, String> headers = createHeaders();
    var response = await http!.get(uri, headers: headers);
    
    if (isValidResponseCode(response)) {
      var data = jsonDecode(response.body);
      return data.map((x) => fromJson(x)).cast<OrderResponse>().toList();
    } else {
      throw Exception("An error occurred!");
    }
  }
}