
import 'dart:convert';

import 'package:the_comfort_zone_mobile/model/category/category_response.dart';
import 'package:the_comfort_zone_mobile/providers/base_provider.dart';

class CategoryProvider extends BaseProvider<CategoryResponse>{
  static const String API_KEY = "Category";
  CategoryProvider(): super(API_KEY);

  @override
  CategoryResponse fromJson(data) {
    return CategoryResponse.fromJson(data);
  }

Future<List<CategoryResponse>> getCategoriesBySpaceId(int id) async {
    var url = Uri.parse("$publicUrl/categories-by-space-id/$id");

    Map<String, String> headers = createHeaders();

    var response = await http!.get(url, headers: headers);

    if (isValidResponseCode(response)) {
      var data = jsonDecode(response.body);
      return data.map((x) => fromJson(x)).cast<CategoryResponse>().toList();
    } else {
      throw Exception("An error occured!");
    }
  }

}