import 'dart:convert';

import 'package:the_comfort_zone_mobile/model/designer/designer_response.dart';
import 'package:the_comfort_zone_mobile/providers/base_provider.dart';

class DesignerProvider extends BaseProvider<DesignerResponse>{
  static const String API_KEY = "Designer";
  DesignerProvider(): super(API_KEY);

  @override
  DesignerResponse fromJson(data) {
    return DesignerResponse.fromJson(data);
  }
}