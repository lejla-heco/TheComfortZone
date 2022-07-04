import 'package:the_comfort_zone_mobile/providers/base_provider.dart';

import '../model/appointment_type/appointment_type_response.dart';

class AppointmentTypeProvider extends BaseProvider<AppointmentTypeResponse> {
  static const String API_KEY = "AppointmentType";
  AppointmentTypeProvider() : super(API_KEY);

  @override
  AppointmentTypeResponse fromJson(data) {
    return AppointmentTypeResponse.fromJson(data);
  }
}
