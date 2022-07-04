import 'package:json_annotation/json_annotation.dart';
part 'appointment_type_response.g.dart';

@JsonSerializable()
class AppointmentTypeResponse {
  int? appointmentTypeId;
  String? name;

  AppointmentTypeResponse();

  factory AppointmentTypeResponse.fromJson(Map<String, dynamic> json) =>
      _$AppointmentTypeResponseFromJson(json);

  /// Connect the generated [_$AppointmentTypeResponseToJson] function to the `toJson` method.
  Map<String, dynamic> toJson() => _$AppointmentTypeResponseToJson(this);
}
