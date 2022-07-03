import 'package:json_annotation/json_annotation.dart';
part 'logged_user.g.dart';

@JsonSerializable()
class LoggedUser {
  int? userId;

  LoggedUser();

  factory LoggedUser.fromJson(Map<String, dynamic> json) => _$LoggedUserFromJson(json);
  /// Connect the generated [_$LoggedUserToJson] function to the `toJson` method.
  Map<String, dynamic> toJson() => _$LoggedUserToJson(this);
}