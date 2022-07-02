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
      ..image = json['image'] as String?
      ..designerName = json['designerName'] as String?
      ..collectionName = json['collectionName'] as String?
      ..categoryName = json['categoryName'] as String?
      ..onSale = json['onSale'] as bool?
      ..regularPrice = (json['regularPrice'] as num?)?.toDouble()
      ..discountPrice = (json['discountPrice'] as num?)?.toDouble()
      ..colors = json['colors'] as String?
      ..dimensions = json['dimensions'] as String?
      ..material = json['material'] as String?
      ..description = json['description'] as String?
      ..favourited = json['favourited'] as bool?;

Map<String, dynamic> _$FurnitureItemResponseToJson(
        FurnitureItemResponse instance) =>
    <String, dynamic>{
      'furnitureItemId': instance.furnitureItemId,
      'name': instance.name,
      'categoryId': instance.categoryId,
      'collectionId': instance.collectionId,
      'materialId': instance.materialId,
      'image': instance.image,
      'designerName': instance.designerName,
      'collectionName': instance.collectionName,
      'categoryName': instance.categoryName,
      'onSale': instance.onSale,
      'regularPrice': instance.regularPrice,
      'discountPrice': instance.discountPrice,
      'colors': instance.colors,
      'dimensions': instance.dimensions,
      'material': instance.material,
      'description': instance.description,
      'favourited': instance.favourited,
    };
