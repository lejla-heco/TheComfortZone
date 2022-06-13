// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'user_response.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

UserResponse _$UserResponseFromJson(Map<String, dynamic> json) => UserResponse()
  ..userId = json['userId'] as int?
  ..firstName = json['firstName'] as String?
  ..lastName = json['lastName'] as String?
  ..username = json['username'] as String?
  ..adress = json['adress'] as String?
  ..phoneNumber = json['phoneNumber'] as String?
  ..email = json['email'] as String?
  ..userType = json['userType'] as String?
  ..fullName = json['fullName'] as String?;

Map<String, dynamic> _$UserResponseToJson(UserResponse instance) =>
    <String, dynamic>{
      'userId': instance.userId,
      'firstName': instance.firstName,
      'lastName': instance.lastName,
      'username': instance.username,
      'adress': instance.adress,
      'phoneNumber': instance.phoneNumber,
      'email': instance.email,
      'userType': instance.userType,
      'fullName': instance.fullName,
    };
