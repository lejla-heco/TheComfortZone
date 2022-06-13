// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'furniture_item_response.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

FurnitureItemResponse _$FurnitureItemResponseFromJson(
        Map<String, dynamic> json) =>
    FurnitureItemResponse()
      ..furnitureItemId = json['furnitureItemId'] as int?
      ..name = json['name'] as String?
      ..categoryId = json['categoryId'] as int?
      ..collectionId = json['collectionId'] as int?
      ..materialId = json['materialId'] as int?
      ..image = json['image'] as String?;

Map<String, dynamic> _$FurnitureItemResponseToJson(
        FurnitureItemResponse instance) =>
    <String, dynamic>{
      'furnitureItemId': instance.furnitureItemId,
      'name': instance.name,
      'categoryId': instance.categoryId,
      'collectionId': instance.collectionId,
      'materialId': instance.materialId,
      'image': instance.image,
    };
