import 'package:the_comfort_zone_mobile/model/furniture_item/furniture_item_response.dart';
import 'package:the_comfort_zone_mobile/providers/base_provider.dart';

class FurnitureItemProvider extends BaseProvider<FurnitureItemResponse>{
  static const String API_KEY = "FurnitureItem";
  FurnitureItemProvider() : super(API_KEY);

  @override
  FurnitureItemResponse fromJson(data){
    return FurnitureItemResponse.fromJson(data);
  }
}
