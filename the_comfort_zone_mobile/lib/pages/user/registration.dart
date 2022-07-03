import 'package:flutter/material.dart';
import '../../widgets/text_input_widget.dart';

class RegistrationPage extends StatelessWidget {
  static const String routeName = "/registration";
  const RegistrationPage({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {

    TextEditingController _firstNameController = TextEditingController();
    TextEditingController _lastNameController = TextEditingController();
    TextEditingController _adressController = TextEditingController();
    TextEditingController _phoneNumberController = TextEditingController();
    TextEditingController _emailController = TextEditingController();
    TextEditingController _usernameController = TextEditingController();
    TextEditingController _passwordController = TextEditingController();
    TextEditingController _passwordConfirmationController = TextEditingController();

    /** WIDGETS */
    
    final txtTitle = Text("Create account",
        style: TextStyle(
            fontSize: 26, fontWeight: FontWeight.bold, color: Colors.white));
    final txtSubtitle = Text("Sign up to get started!",
        style: TextStyle(
          fontSize: 20,
          color: Colors.grey.shade400,
        ));
    Widget MainButtonWidget(){
  return Container(
    height: 50,
    decoration: BoxDecoration(
        borderRadius: BorderRadius.circular(10),
        gradient: const LinearGradient(colors: [
          Color.fromARGB(255, 216, 174, 130),
          Color.fromARGB(255, 114, 75, 50)
        ])),
    child: const Center(
        child: Text(
      "Sign up",
      style: TextStyle(
          fontSize: 20, fontWeight: FontWeight.bold, color: Colors.white),
    )),
  );
  }


    final txtFirstName = TextInputWidget(label: "First name", controller: _firstNameController);
    final txtLastName = TextInputWidget(label: "Last name", controller: _lastNameController);
    final txtAdress = TextInputWidget(label: "Adress", controller: _adressController);
    final txtPhoneNumber = TextInputWidget(label: "Phone number", controller: _phoneNumberController);
    final txtEmail = TextInputWidget(label: "Email", controller: _emailController);
    final txtUsername = TextInputWidget(label: "Username", controller: _usernameController);
    final txtPassword = TextInputWidget(label: "Password", controller: _passwordController);
    final txtPasswordConfirmation =
        TextInputWidget(label: "Password confirmation", controller: _passwordConfirmationController);

    /** SCAFFOLD */

    return Scaffold(
      backgroundColor: Colors.white,
      body: SingleChildScrollView(
          child: Container(
        height: MediaQuery.of(context).size.height,
        width: MediaQuery.of(context).size.width,
        padding: EdgeInsets.only(left: 16, right: 16),
        decoration: const BoxDecoration(
            image: DecorationImage(
          image: AssetImage("assets/images/registration-background.jpg"),
          fit: BoxFit.fill,
        )),
        child: ListView(
          children: [
            const SizedBox(
              height: 50,
            ),
            txtTitle,
            const SizedBox(
              height: 6,
            ),
            txtSubtitle,
            const SizedBox(
              height: 25,
            ),
            txtFirstName,
            const SizedBox(
              height: 16,
            ),
            txtLastName,
            const SizedBox(
              height: 16,
            ),
            txtAdress,
            const SizedBox(
              height: 16,
            ),
            txtPhoneNumber,
            const SizedBox(
              height: 16,
            ),
            txtEmail,
            const SizedBox(
              height: 16,
            ),
            txtUsername,
            const SizedBox(
              height: 16,
            ),
            txtPassword,
            const SizedBox(
              height: 16,
            ),
            txtPasswordConfirmation,
            const SizedBox(
              height: 12,
            ),
            const SizedBox(
              height: 20,
            ),
            MainButtonWidget(),
            const SizedBox(
              height: 20,
            ),
          ],
        ),
      )),
    );
  }
}