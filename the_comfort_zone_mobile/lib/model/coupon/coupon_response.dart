import 'package:json_annotation/json_annotation.dart';
part 'coupon_response.g.dart';

@JsonSerializable()
class CouponResponse {
  int? couponId;
  String? couponCode;
  int? discount;

  CouponResponse();

  factory CouponResponse.fromJson(Map<String, dynamic> json) =>
      _$CouponResponseFromJson(json);

  /// Connect the generated [_$CouponResponseToJson] function to the `toJson` method.
  Map<String, dynamic> toJson() => _$CouponResponseToJson(this);
}
