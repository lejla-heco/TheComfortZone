import 'dart:convert';

import 'package:the_comfort_zone_mobile/model/furniture_item/furniture_item_response.dart';
import 'package:the_comfort_zone_mobile/providers/base_provider.dart';

import '../utils/logged_in_user.dart';

class FurnitureItemProvider extends BaseProvider<FurnitureItemResponse> {
  static const String apiRoute = "FurnitureItem";
  FurnitureItemProvider() : super(apiRoute);

  @override
  FurnitureItemResponse fromJson(data) {
    return FurnitureItemResponse.fromJson(data);
  }

  Future<String> likeFurnitureItem(int furnitureItemId) async {
    var url =
        Uri.parse("$publicUrl/like/${LoggedInUser.userId}/$furnitureItemId");

    Map<String, String> headers = createHeaders();

    var response = await http!.get(url, headers: headers);

    if (isValidResponseCode(response)) {
      return response.body.toString();
    } else {
      throw Exception("An error occured!");
    }
  }

  Future<List<FurnitureItemResponse>> getFurnitureItemsUserData([dynamic search]) async {
    var url = "$publicUrl/furniture-items-with-likes/${LoggedInUser.userId}";

    if (search != null) {
      String queryString = getQueryString(search);
      url = url + "?" + queryString;
    }

    var uri = Uri.parse(url);

    Map<String, String> headers = createHeaders();
    var response = await http!.get(uri, headers: headers);
    
    if (isValidResponseCode(response)) {
      var data = jsonDecode(response.body);
      return data.map((x) => fromJson(x)).cast<FurnitureItemResponse>().toList();
    } else {
      throw Exception("An error occurred!");
    }
  }

  Future<List<FurnitureItemResponse>> getFavourites([dynamic search]) async {
    var url = "$publicUrl/favourites/${LoggedInUser.userId}";

    if (search != null) {
      String queryString = getQueryString(search);
      url = url + "?" + queryString;
    }

    var uri = Uri.parse(url);

    Map<String, String> headers = createHeaders();
    var response = await http!.get(uri, headers: headers);
    
    if (isValidResponseCode(response)) {
      var data = jsonDecode(response.body);
      return data.map((x) => fromJson(x)).cast<FurnitureItemResponse>().toList();
    } else {
      throw Exception("An error occurred!");
    }
  }

  Future<String> dislikeFurnitureItem(int furnitureItemId) async {
    var url =
        Uri.parse("$publicUrl/dislike/${LoggedInUser.userId}/$furnitureItemId");

    Map<String, String> headers = createHeaders();

    var response = await http!.get(url, headers: headers);

    if (isValidResponseCode(response)) {
      return response.body.toString();
    } else {
      throw Exception("An error occured!");
    }
  }

    Future<List<FurnitureItemResponse>> getRecommendedItems(int furnitureItemId) async {
    var url = "$publicUrl/reccommend/$furnitureItemId";

    var uri = Uri.parse(url);
    Map<String, String> headers = createHeaders();
    var response = await http!.get(uri, headers: headers);
    
    if (isValidResponseCode(response)) {
      var data = jsonDecode(response.body);
      return data.map((x) => fromJson(x)).cast<FurnitureItemResponse>().toList();
    } else {
      throw Exception("An error occurred!");
    }
  }

}
