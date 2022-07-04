// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'coupon_response.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

CouponResponse _$CouponResponseFromJson(Map<String, dynamic> json) =>
    CouponResponse()
      ..couponId = json['couponId'] as int?
      ..couponCode = json['couponCode'] as String?
      ..discount = json['discount'] as int?;

Map<String, dynamic> _$CouponResponseToJson(CouponResponse instance) =>
    <String, dynamic>{
      'couponId': instance.couponId,
      'couponCode': instance.couponCode,
      'discount': instance.discount,
    };
