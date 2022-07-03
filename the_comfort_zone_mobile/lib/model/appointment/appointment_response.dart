import 'package:json_annotation/json_annotation.dart';
part 'appointment_response.g.dart';

@JsonSerializable()
class AppointmentResponse {
  int? appointmentId;
  DateTime? appointmentDate;
  int? duration;
  double? totalPrice;
  bool? approved;
  String? designerName;
  String? type;
  String? appointmentNumber;

  AppointmentResponse();

  factory AppointmentResponse.fromJson(Map<String, dynamic> json) =>
      _$AppointmentResponseFromJson(json);

  /// Connect the generated [_$AppointmentResponseToJson] function to the `toJson` method.
  Map<String, dynamic> toJson() => _$AppointmentResponseToJson(this);
}
