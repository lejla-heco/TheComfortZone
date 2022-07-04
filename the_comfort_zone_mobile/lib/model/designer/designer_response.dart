import 'package:json_annotation/json_annotation.dart';
part 'designer_response.g.dart';

@JsonSerializable()
class DesignerResponse {
  int? designerId;
  String? name;
  double? consultationPrice;

  DesignerResponse();

  factory DesignerResponse.fromJson(Map<String, dynamic> json) => _$DesignerResponseFromJson(json);
  /// Connect the generated [_$DesignerResponseToJson] function to the `toJson` method.
  Map<String, dynamic> toJson() => _$DesignerResponseToJson(this);
}
