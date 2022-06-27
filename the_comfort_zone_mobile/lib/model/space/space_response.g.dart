// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'space_response.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

SpaceResponse _$SpaceResponseFromJson(Map<String, dynamic> json) =>
    SpaceResponse()
      ..spaceId = json['spaceId'] as int?
      ..name = json['name'] as String?
      ..image = json['image'] as String?;

Map<String, dynamic> _$SpaceResponseToJson(SpaceResponse instance) =>
    <String, dynamic>{
      'spaceId': instance.spaceId,
      'name': instance.name,
      'image': instance.image,
    };
