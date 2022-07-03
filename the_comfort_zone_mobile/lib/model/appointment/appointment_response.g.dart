// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'appointment_response.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

AppointmentResponse _$AppointmentResponseFromJson(Map<String, dynamic> json) =>
    AppointmentResponse()
      ..appointmentId = json['appointmentId'] as int?
      ..appointmentDate = json['appointmentDate'] == null
          ? null
          : DateTime.parse(json['appointmentDate'] as String)
      ..duration = json['duration'] as int?
      ..totalPrice = (json['totalPrice'] as num?)?.toDouble()
      ..approved = json['approved'] as bool?
      ..designerName = json['designerName'] as String?
      ..type = json['type'] as String?
      ..appointmentNumber = json['appointmentNumber'] as String?;

Map<String, dynamic> _$AppointmentResponseToJson(
        AppointmentResponse instance) =>
    <String, dynamic>{
      'appointmentId': instance.appointmentId,
      'appointmentDate': instance.appointmentDate?.toIso8601String(),
      'duration': instance.duration,
      'totalPrice': instance.totalPrice,
      'approved': instance.approved,
      'designerName': instance.designerName,
      'type': instance.type,
      'appointmentNumber': instance.appointmentNumber,
    };
