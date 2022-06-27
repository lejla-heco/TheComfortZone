import 'dart:ffi';

import 'package:json_annotation/json_annotation.dart';
part 'category_response.g.dart';

@JsonSerializable()
class CategoryResponse{
  int? categoryId;
  String? name;

  CategoryResponse() {}

 factory CategoryResponse.fromJson(Map<String, dynamic> json) =>
      _$CategoryResponseFromJson(json);

  /// Connect the generated [_$CategoryResponseToJson] function to the `toJson` method.
  Map<String, dynamic> toJson() => _$CategoryResponseToJson(this);

}