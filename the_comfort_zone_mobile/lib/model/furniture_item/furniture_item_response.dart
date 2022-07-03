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
  String? designerName;
  String? collectionName;
  String? categoryName;
  bool? onSale;
  double? regularPrice;
  double? discountPrice;
  String? colors;
  String? dimensions;
  String? material;
  String? description;
  bool? favourited;

  FurnitureItemResponse();

  factory FurnitureItemResponse.fromJson(Map<String, dynamic> json) => _$FurnitureItemResponseFromJson(json);
  /// Connect the generated [_$FurnitureItemResponseToJson] function to the `toJson` method.
  Map<String, dynamic> toJson() => _$FurnitureItemResponseToJson(this);
}