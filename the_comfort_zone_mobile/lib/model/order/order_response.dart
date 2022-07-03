import 'package:json_annotation/json_annotation.dart';
part 'order_response.g.dart';

@JsonSerializable()
class OrderResponse {
  int? orderId;
  DateTime? orderDate;
  String? status;
  int? orderNumber;
  int? noip;
  double? totalPrice;

  OrderResponse(){}

  factory OrderResponse.fromJson(Map<String, dynamic> json) => _$OrderResponseFromJson(json);
  /// Connect the generated [_$OrderResponseToJson] function to the `toJson` method.
  Map<String, dynamic> toJson() => _$OrderResponseToJson(this);
}
