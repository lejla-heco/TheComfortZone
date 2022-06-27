import 'dart:ffi';

import 'package:json_annotation/json_annotation.dart';
part 'space_response.g.dart';

@JsonSerializable()
class SpaceResponse {
  int? spaceId;
  String? name;
  String? image;

  SpaceResponse() {}

  factory SpaceResponse.fromJson(Map<String, dynamic> json) =>
      _$SpaceResponseFromJson(json);

  /// Connect the generated [_$SpaceResponseToJson] function to the `toJson` method.
  Map<String, dynamic> toJson() => _$SpaceResponseToJson(this);
}
