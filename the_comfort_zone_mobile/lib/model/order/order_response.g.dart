// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'order_response.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

OrderResponse _$OrderResponseFromJson(Map<String, dynamic> json) =>
    OrderResponse()
      ..orderId = json['orderId'] as int?
      ..orderDate = json['orderDate'] == null
          ? null
          : DateTime.parse(json['orderDate'] as String)
      ..status = json['status'] as String?
      ..orderNumber = json['orderNumber'] as int?
      ..noip = json['noip'] as int?
      ..totalPrice = (json['totalPrice'] as num?)?.toDouble();

Map<String, dynamic> _$OrderResponseToJson(OrderResponse instance) =>
    <String, dynamic>{
      'orderId': instance.orderId,
      'orderDate': instance.orderDate?.toIso8601String(),
      'status': instance.status,
      'orderNumber': instance.orderNumber,
      'noip': instance.noip,
      'totalPrice': instance.totalPrice,
    };
