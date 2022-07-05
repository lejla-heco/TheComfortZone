import 'package:email_validator/email_validator.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';
import 'package:the_comfort_zone_mobile/model/user/user_insert_request.dart';
import '../../providers/user_provider.dart';
import '../../utils/credentials_helper.dart';
import '../../utils/logged_in_user.dart';
import '../../widgets/alert_dialog_widget.dart';
import '../../widgets/text_input_widget.dart';
import '../home_page/navigation_page.dart';

class RegistrationPage extends StatefulWidget {
  static const String routeName = "/registration";
  const RegistrationPage({Key? key}) : super(key: key);

  @override
  _RegistrationPageState createState() => _RegistrationPageState();
}

class _RegistrationPageState extends State<RegistrationPage> {
  late UserProvider _userProvider;

  final TextEditingController _firstNameController = TextEditingController();
  final TextEditingController _lastNameController = TextEditingController();
  final TextEditingController _adressController = TextEditingController();
  final TextEditingController _phoneNumberController = TextEditingController();
  final TextEditingController _emailController = TextEditingController();
  final TextEditingController _usernameController = TextEditingController();
  final TextEditingController _passwordController = TextEditingController();
  final TextEditingController _passwordConfirmationController =
      TextEditingController();
  FocusNode focusNode = FocusNode();

  dynamic response;
  UserInsertRequest request = UserInsertRequest();
  final _formKey = GlobalKey<FormState>();
  final _mandatoryField = "field cannot be left blank!";

  bool _isObscure = true;
  bool _isObscureConfirmation = true;

  @override
  void initState() {
    _userProvider = context.read<UserProvider>();
    setState(() {});
    super.initState();
  }

  @override
  Widget build(BuildContext context) {
    final txtFirstName =
        TextInputWidget(label: "First name", controller: _firstNameController);
    final txtLastName =
        TextInputWidget(label: "Last name", controller: _lastNameController);
    final txtAddress =
        TextInputWidget(label: "Address", controller: _adressController);

    final txtPhoneNumber = TextFormField(
      validator: (value) {
        if (value == null || value.isEmpty) {
          return "Phone number " + _mandatoryField;
        } else if (value != null && value.isNotEmpty) {
          if (!value.startsWith(RegExp(r'^[0-9]{3}\/[0-9]{3}-[0-9]{3}$'))) {
            return "Wrong phone number format!";
          }
        } else {
          return null;
        }
      },
      controller: _phoneNumberController,
      style: const TextStyle(color: Colors.white),
      decoration: InputDecoration(
          labelText: "Phone Number",
          labelStyle: const TextStyle(fontSize: 16, color: Colors.white),
          enabledBorder: OutlineInputBorder(
              borderRadius: BorderRadius.circular(10),
              borderSide: BorderSide(color: Colors.grey.shade300)),
          focusedBorder: OutlineInputBorder(
            borderRadius: BorderRadius.circular(10),
            borderSide:
                const BorderSide(color: Color.fromARGB(255, 114, 75, 50)),
          )),
    );

    final txtEmail = TextFormField(
      validator: (value) {
        if (value == null || value.isEmpty) {
          return "Email " + _mandatoryField;
        } else if (!EmailValidator.validate(value)) {
          return "Wrong email format!";
        } else {
          return null;
        }
      },
      controller: _emailController,
      style: const TextStyle(color: Colors.white),
      decoration: InputDecoration(
          labelText: "Email",
          labelStyle: const TextStyle(fontSize: 16, color: Colors.white),
          enabledBorder: OutlineInputBorder(
              borderRadius: BorderRadius.circular(10),
              borderSide: BorderSide(color: Colors.grey.shade300)),
          focusedBorder: OutlineInputBorder(
            borderRadius: BorderRadius.circular(10),
            borderSide:
                const BorderSide(color: Color.fromARGB(255, 114, 75, 50)),
          )),
    );

    final txtUsername =
        TextInputWidget(label: "Username", controller: _usernameController);

    final txtPassword = TextFormField(
      validator: (value) {
        if (value == null || value.isEmpty) {
          return "Password " + _mandatoryField;
        } else if (value != null && value.isNotEmpty) {
          if (value.length < 8) {
            return "Minimum password length is 8 characters!";
          }
        } else {
          return null;
        }
      },
      controller: _passwordController,
      obscureText: _isObscure,
      style: const TextStyle(color: Colors.white),
      decoration: InputDecoration(
          suffixIcon: IconButton(
              icon: Icon(
                _isObscure ? Icons.visibility : Icons.visibility_off,
              ),
              onPressed: () {
                setState(() {
                  _isObscure = !_isObscure;
                });
              }),
          labelText: "Password",
          labelStyle: const TextStyle(fontSize: 16, color: Colors.white),
          enabledBorder: OutlineInputBorder(
              borderRadius: BorderRadius.circular(10),
              borderSide: BorderSide(color: Colors.grey.shade300)),
          focusedBorder: OutlineInputBorder(
            borderRadius: BorderRadius.circular(10),
            borderSide:
                const BorderSide(color: Color.fromARGB(255, 114, 75, 50)),
          )),
    );

    final txtPasswordConfirmation = TextFormField(
      validator: (value) {
        if (value == null || value.isEmpty) {
          return "Password confirmation " + _mandatoryField;
        } else if (value != null && value.isNotEmpty) {
          if (value != _passwordController.text) {
            return "Password and password confirmation must be the same!";
          }
        } else {
          return null;
        }
      },
      controller: _passwordConfirmationController,
      obscureText: _isObscureConfirmation,
      style: const TextStyle(color: Colors.white),
      decoration: InputDecoration(
          suffixIcon: IconButton(
              icon: Icon(
                _isObscureConfirmation
                    ? Icons.visibility
                    : Icons.visibility_off,
              ),
              onPressed: () {
                setState(() {
                  _isObscureConfirmation = !_isObscureConfirmation;
                });
              }),
          labelText: "Password confirmation",
          labelStyle: const TextStyle(fontSize: 16, color: Colors.white),
          enabledBorder: OutlineInputBorder(
              borderRadius: BorderRadius.circular(10),
              borderSide: BorderSide(color: Colors.grey.shade300)),
          focusedBorder: OutlineInputBorder(
            borderRadius: BorderRadius.circular(10),
            borderSide:
                const BorderSide(color: Color.fromARGB(255, 114, 75, 50)),
          )),
    );

    final btnRegister = InkWell(
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
          "Register",
          style: TextStyle(
              fontSize: 20, fontWeight: FontWeight.bold, color: Colors.white),
        )),
      ),
      onTap: () async {
        if (_formKey.currentState!.validate()) {
          request.firstName = _firstNameController.text;
          request.lastName = _lastNameController.text;
          request.adress = _adressController.text;
          request.email = _emailController.text;
          request.phoneNumber = _phoneNumberController.text;
          request.username = _usernameController.text;
          request.password = _passwordController.text;
          request.passwordConfirmation = _passwordConfirmationController.text;
          request.roleName = "User";
          if (request.password != request.passwordConfirmation) {
            showDialog(
                context: context,
                builder: (BuildContext context) => AlertDialogWidget(
                      title: "Warning",
                      message:
                          "Password and password confirmation are not the same!\nConfirm your password!",
                      context: context,
                    ));
          } else {
            try {
              await _userProvider.insert(request.toJson());
              await showDialog (
                  context: context,
                  builder: (BuildContext dialogContex) => AlertDialogWidget(
                        title: "Success",
                        message: "Successfully created profile!",
                        context: dialogContex,
                      ));
              Authorization.username = _usernameController.text;
              Authorization.password = _passwordController.text;

              var loggedInUserId = await _userProvider.getLoggedInUserId();
              LoggedInUser.userId = loggedInUserId;

              Navigator.popAndPushNamed(context, NavigationPage.routeName);
            } catch (e) {
              showDialog(
                  context: context,
                  builder: (BuildContext dialogContex) => AlertDialogWidget(
                        title: "Error",
                        message: "Username is already taken!",
                        context: dialogContex,
                      ));
            }
          }
        }
      },
    );

    final txtTitle = Text("Create account",
        style: TextStyle(
            fontSize: 26, fontWeight: FontWeight.bold, color: Colors.white));
    final txtSubtitle = Text("Sign up to get started!",
        style: TextStyle(
          fontSize: 20,
          color: Colors.grey.shade400,
        ));

    return Scaffold(
        body: Center(
      child: Container(
        height: MediaQuery.of(context).size.height,
        width: MediaQuery.of(context).size.width,
        padding: const EdgeInsets.only(left: 16, right: 16),
        decoration: const BoxDecoration(
            image: DecorationImage(
          image: AssetImage("assets/images/registration-background.jpg"),
          fit: BoxFit.fill,
        )),
        child: ListView(children: [
          Column(
              crossAxisAlignment: CrossAxisAlignment.center,
              mainAxisAlignment: MainAxisAlignment.center,
              children: [
                const SizedBox(height: 20.0),
                Form(
                  key: _formKey,
                  autovalidateMode: AutovalidateMode.onUserInteraction,
                  child: Column(
                      crossAxisAlignment: CrossAxisAlignment.center,
                      mainAxisAlignment: MainAxisAlignment.center,
                      children: [
                        const SizedBox(
                          height: 10,
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
                        const SizedBox(height: 16),
                        txtLastName,
                        const SizedBox(height: 16),
                        txtAddress,
                        const SizedBox(height: 16),
                        txtPhoneNumber,
                        const SizedBox(height: 16),
                        txtEmail,
                        const SizedBox(height: 16),
                        txtUsername,
                        const SizedBox(height: 16),
                        txtPassword,
                        const SizedBox(height: 16),
                        txtPasswordConfirmation,
                        const SizedBox(height: 20),
                        btnRegister,
                        const SizedBox(height: 20),
                      ]),
                ),
              ]),
        ]),
      ),
    ));
  }
}
