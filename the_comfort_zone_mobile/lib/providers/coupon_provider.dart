import 'dart:convert';

import 'package:the_comfort_zone_mobile/providers/base_provider.dart';

import '../model/coupon/coupon_response.dart';
import '../utils/logged_in_user.dart';

class CouponProvider extends BaseProvider<CouponResponse> {
  static const String API_KEY = "Coupon";
  CouponProvider() : super(API_KEY);

  @override
  CouponResponse fromJson(data) {
    return CouponResponse.fromJson(data);
  }

  Future<List<CouponResponse>> getCouponsByUserId() async {
    var url = Uri.parse("$publicUrl/coupons-by-user-id/${LoggedInUser.userId}");

    Map<String, String> headers = createHeaders();

    var response = await http!.get(url, headers: headers);

    if (isValidResponseCode(response)) {
      var data = jsonDecode(response.body);
      return data.map((x) => fromJson(x)).cast<CouponResponse>().toList();
    } else {
      throw Exception("An error occured!");
    }
  }
}
