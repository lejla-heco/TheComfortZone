import 'package:flutter/material.dart';
import 'package:provider/provider.dart';
import 'package:the_comfort_zone_mobile/pages/user/registration.dart';
import 'package:the_comfort_zone_mobile/utils/credentials_helper.dart';
import 'package:the_comfort_zone_mobile/utils/logged_in_user.dart';
import '../../providers/user_provider.dart';
import '../../widgets/text_input_widget.dart';
import '../home_page/navigation_page.dart';

class LoginPage extends StatelessWidget {
  late UserProvider _userProvider;
  final TextEditingController _usernameController = TextEditingController();
  final TextEditingController _passwordController = TextEditingController();

  @override
  Widget build(BuildContext context) {
    _userProvider = Provider.of<UserProvider>(context, listen: false);

    final txtUsername =
        TextInputWidget(label: "Username", controller: _usernameController);
    final txtPassword =
        TextInputWidget(label: "Password", controller: _passwordController);
/** WIDGETS */

    final txtRegister = InkWell(
      child: const Text("Sign up ",
          style: TextStyle(
              fontSize: 17,
              fontWeight: FontWeight.bold,
              color: Colors.white70)),
      onTap: () async {
        Navigator.pushNamed(context, RegistrationPage.routeName);
      },
    );
    final btnLogin = InkWell(
      child: Container(
        height: 50,
        decoration: BoxDecoration(
            borderRadius: BorderRadius.circular(10),
            gradient: const LinearGradient(colors: [
              Color.fromARGB(255, 216, 174, 130),
              Color.fromARGB(255, 114, 75, 50)
            ])),
        child: const Center(
            child: Text(
          "Login",
          style: TextStyle(
              fontSize: 20, fontWeight: FontWeight.bold, color: Colors.white),
        )),
      ),
      onTap: () async {
        try {
          Authorization.username = _usernameController.text;
          Authorization.password = _passwordController.text;

          var loggedInUserId = await _userProvider.getLoggedInUserId();
          LoggedInUser.userId = loggedInUserId;

          print(LoggedInUser.userId);

          Navigator.popAndPushNamed(context, NavigationPage.routeName);
        } catch (e) {
          showDialog(
              context: context,
              builder: (BuildContext context) => AlertDialog(
                    title: const Text("Error"),
                    content: Text(e.toString()),
                    actions: [
                      TextButton(
                          onPressed: () => Navigator.pop(context),
                          child: const Text("Ok"))
                    ],
                  ));
        }
      },
    );
    const txtWellcome = Text("Wellcome To",
        style: TextStyle(
            fontSize: 22, fontWeight: FontWeight.bold, color: Colors.white));
    const txtTitle = Text("The Comfort Zone",
        style: TextStyle(
            fontSize: 26, fontWeight: FontWeight.bold, color: Colors.white));
    final txtSubtitle = Text("Sign in to continue!",
        style: TextStyle(
          fontSize: 20,
          color: Colors.grey.shade400,
        ));
    final txtFooter = Padding(
      padding: const EdgeInsets.only(bottom: 20),
      child: Row(
        mainAxisAlignment: MainAxisAlignment.center,
        children: [
          const Text("I'm a new user. ",
              style: TextStyle(
                  fontSize: 15,
                  fontWeight: FontWeight.bold,
                  color: Colors.white)),
          txtRegister,
        ],
      ),
    );

/** SCAFFOLD */

    return Scaffold(
        backgroundColor: Colors.white,
        body: SingleChildScrollView(
          child: Container(
              height: MediaQuery.of(context).size.height,
              width: MediaQuery.of(context).size.width,
              padding: const EdgeInsets.only(left: 16, right: 16),
              decoration: const BoxDecoration(
                  image: DecorationImage(
                image: AssetImage("assets/images/background.jpg"),
                fit: BoxFit.fill,
              )),
              child: Column(
                mainAxisAlignment: MainAxisAlignment.spaceBetween,
                crossAxisAlignment: CrossAxisAlignment.start,
                children: [
                  Column(
                    crossAxisAlignment: CrossAxisAlignment.start,
                    children: [
                      const SizedBox(
                        height: 50,
                      ),
                      txtWellcome,
                      const SizedBox(
                        height: 6,
                      ),
                      txtTitle,
                      const SizedBox(
                        height: 6,
                      ),
                      txtSubtitle
                    ],
                  ),
                  Column(
                    children: [
                      const SizedBox(
                        height: 100,
                      ),
                      txtUsername,
                      const SizedBox(
                        height: 16,
                      ),
                      txtPassword,
                      const SizedBox(
                        height: 32,
                      ),
                      btnLogin,
                      const SizedBox(
                        height: 100,
                      ),
                      txtFooter,
                    ],
                  )
                ],
              )),
        ));
  }
}
