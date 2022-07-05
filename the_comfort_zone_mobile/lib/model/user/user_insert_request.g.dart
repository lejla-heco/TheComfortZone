// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'user_insert_request.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

UserInsertRequest _$UserInsertRequestFromJson(Map<String, dynamic> json) =>
    UserInsertRequest()
      ..firstName = json['firstName'] as String?
      ..lastName = json['lastName'] as String?
      ..username = json['username'] as String?
      ..adress = json['adress'] as String?
      ..phoneNumber = json['phoneNumber'] as String?
      ..email = json['email'] as String?
      ..password = json['password'] as String?
      ..passwordConfirmation = json['passwordConfirmation'] as String?
      ..roleName = json['roleName'] as String?;

Map<String, dynamic> _$UserInsertRequestToJson(UserInsertRequest instance) =>
    <String, dynamic>{
      'firstName': instance.firstName,
      'lastName': instance.lastName,
      'username': instance.username,
      'adress': instance.adress,
      'phoneNumber': instance.phoneNumber,
      'email': instance.email,
      'password': instance.password,
      'passwordConfirmation': instance.passwordConfirmation,
      'roleName': instance.roleName,
    };
