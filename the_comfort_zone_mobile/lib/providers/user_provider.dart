import '../model/user/user_response.dart';
import 'base_provider.dart';

class UserProvider extends BaseProvider<UserResponse>{
  static const String API_KEY = "User";
  UserProvider() : super(API_KEY);

  @override
  UserResponse fromJson(data){
    return UserResponse.fromJson(data);
  }
}