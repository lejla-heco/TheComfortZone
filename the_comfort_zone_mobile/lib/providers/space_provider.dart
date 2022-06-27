import 'dart:convert';

import 'package:the_comfort_zone_mobile/model/space/space_response.dart';
import 'package:the_comfort_zone_mobile/providers/base_provider.dart';

class SpaceProvider extends BaseProvider<SpaceResponse>{
  static const String API_KEY = "Space";
  SpaceProvider(): super(API_KEY);

@override
  SpaceResponse fromJson(data) {
    return SpaceResponse.fromJson(data);
  }

  Future<List<SpaceResponse>> getSpacesWithCategoryData() async {
    var url = Uri.parse("$publicUrl/spaces-with-categories");

    Map<String, String> headers = createHeaders();

    var response = await http!.get(url, headers: headers);

    if (isValidResponseCode(response)) {
      var data = jsonDecode(response.body);
      return data.map((x) => fromJson(x)).cast<SpaceResponse>().toList();
    } else {
      throw Exception("An error occured!");
    }
  }

}