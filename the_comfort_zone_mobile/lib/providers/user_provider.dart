import 'dart:convert';

import '../model/user/logged_user.dart';
import '../model/user/user_response.dart';
import 'base_provider.dart';

class UserProvider extends BaseProvider<UserResponse>{
  static const String API_KEY = "User";
  UserProvider() : super(API_KEY);

  @override
  UserResponse fromJson(data){
    return UserResponse.fromJson(data);
  }

  Future<LoggedUser> getLoggedInUserId() async {
    var url = Uri.parse("$publicUrl/user-role");

    Map<String, String> headers = createHeaders();

    var response = await http!.get(url, headers: headers);

    if (isValidResponseCode(response)) {
      var data = jsonDecode(response.body);

      LoggedUser loggedUser = LoggedUser();
      loggedUser.userId = data['userId'];

      return loggedUser;
    } else {
      throw Exception("An error occured!");
    }
  }
}