// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'designer_response.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

DesignerResponse _$DesignerResponseFromJson(Map<String, dynamic> json) =>
    DesignerResponse()
      ..designerId = json['designerId'] as int?
      ..name = json['name'] as String?
      ..consultationPrice = (json['consultationPrice'] as num?)?.toDouble();

Map<String, dynamic> _$DesignerResponseToJson(DesignerResponse instance) =>
    <String, dynamic>{
      'designerId': instance.designerId,
      'name': instance.name,
      'consultationPrice': instance.consultationPrice,
    };
