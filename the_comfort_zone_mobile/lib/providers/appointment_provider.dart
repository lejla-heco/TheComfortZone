import 'dart:convert';

import 'package:the_comfort_zone_mobile/model/appointment/appointment_response.dart';
import 'package:the_comfort_zone_mobile/providers/base_provider.dart';

import '../utils/logged_in_user.dart';

class AppointmentProvider extends BaseProvider<AppointmentResponse> {
  static const String API_ROUTE = "Appointment";
  AppointmentProvider() : super(API_ROUTE);

  @override
  AppointmentResponse fromJson(data) {
    return AppointmentResponse.fromJson(data);
  }

  Future<List<AppointmentResponse>> getAppointmentsByUserId(
      [dynamic search]) async {
    var url = "$publicUrl/appointments-by-user/${LoggedInUser.userId}";

    if (search != null) {
      String queryString = getQueryString(search);
      url = url + "?" + queryString;
    }

    var uri = Uri.parse(url);

    Map<String, String> headers = createHeaders();
    var response = await http!.get(uri, headers: headers);

    if (isValidResponseCode(response)) {
      var data = jsonDecode(response.body);
      return data.map((x) => fromJson(x)).cast<AppointmentResponse>().toList();
    } else {
      throw Exception("An error occurred!");
    }
  }
}
