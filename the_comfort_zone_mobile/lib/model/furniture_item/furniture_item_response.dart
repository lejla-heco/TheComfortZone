import 'dart:ffi';

import 'package:json_annotation/json_annotation.dart';
part 'furniture_item_response.g.dart';

@JsonSerializable()
class FurnitureItemResponse{
  int? furnitureItemId;
  String? name;
  int? categoryId;
  int? collectionId;
  int? materialId;
  String? image;

  FurnitureItemResponse(){}

  factory FurnitureItemResponse.fromJson(Map<String, dynamic> json) => _$FurnitureItemResponseFromJson(json);
  /// Connect the generated [_$FurnitureItemResponseToJson] function to the `toJson` method.
  Map<String, dynamic> toJson() => _$FurnitureItemResponseToJson(this);
  
}