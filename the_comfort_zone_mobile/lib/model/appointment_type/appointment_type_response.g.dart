// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'appointment_type_response.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

AppointmentTypeResponse _$AppointmentTypeResponseFromJson(
        Map<String, dynamic> json) =>
    AppointmentTypeResponse()
      ..appointmentTypeId = json['appointmentTypeId'] as int?
      ..name = json['name'] as String?;

Map<String, dynamic> _$AppointmentTypeResponseToJson(
        AppointmentTypeResponse instance) =>
    <String, dynamic>{
      'appointmentTypeId': instance.appointmentTypeId,
      'name': instance.name,
    };
