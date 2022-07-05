import 'package:email_validator/email_validator.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';
import 'package:the_comfort_zone_mobile/model/user/user_response.dart';
import 'package:the_comfort_zone_mobile/model/user/user_update_request.dart';
import 'package:the_comfort_zone_mobile/utils/logged_in_user.dart';
import '../../providers/user_provider.dart';
import '../../widgets/alert_dialog_widget.dart';
import '../../widgets/text_input_widget.dart';

class UserInformationPage extends StatefulWidget {
  static const String routeName = "/user-information";
  const UserInformationPage({Key? key}) : super(key: key);

  @override
  State<UserInformationPage> createState() => _UserInformationPageState();
}

class _UserInformationPageState extends State<UserInformationPage> {
  late UserProvider _userProvider;
  UserResponse user = UserResponse();

  @override
  void initState() {
    _userProvider = context.read<UserProvider>();
    WidgetsBinding.instance.addPostFrameCallback((_) async {
      await loadUserData();
      setState(() {});
    });
    super.initState();
  }

  Future<UserResponse> loadUserData() async {
    var apiData = await _userProvider.getById(LoggedInUser.userId!);
    return apiData;
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        iconTheme: const IconThemeData(color: Colors.white),
        title: const Text('My Account', style: TextStyle(color: Colors.white)),
        backgroundColor: Colors.black,
        centerTitle: true,
        elevation: 0.0,
      ),
      backgroundColor: Colors.white,
      body: body(),
    );
  }

  Widget body() {
    const _mandatoryField = "field cannot be left blank!";
    final _formKey = GlobalKey<FormState>();
    UserUpdateRequest request = UserUpdateRequest();

    TextEditingController _firstNameController = TextEditingController();
    TextEditingController _lastNameController = TextEditingController();
    TextEditingController _adressController = TextEditingController();
    TextEditingController _phoneNumberController = TextEditingController();
    TextEditingController _emailController = TextEditingController();
    TextEditingController _usernameController = TextEditingController();
    TextEditingController _passwordController = TextEditingController();
    TextEditingController _passwordConfirmationController =
        TextEditingController();

    final txtFirstName =
        TextInputWidget(label: "First name", controller: _firstNameController);
    final txtLastName =
        TextInputWidget(label: "Last name", controller: _lastNameController);
    final txtAdress =
        TextInputWidget(label: "Adress", controller: _adressController);
    final txtUsername =
        TextInputWidget(label: "Username", controller: _usernameController);

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

    final txtPassword = TextFormField(
      validator: (value) {
        if (value != null && value.isNotEmpty) {
          if (value.length < 8) {
            return "Minimum password length is 8 characters!";
          }
        } else {
          return null;
        }
      },
      controller: _passwordController,
      obscureText: true,
      style: const TextStyle(color: Colors.white),
      decoration: InputDecoration(
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
        if (value != null && value.isNotEmpty) {
          if (value != _passwordController.text) {
            return "Password and password confirmation must be the same!";
          }
        } else {
          return null;
        }
      },
      controller: _passwordConfirmationController,
      obscureText: true,
      style: const TextStyle(color: Colors.white),
      decoration: InputDecoration(
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

    final btnUpdate = Material(
      elevation: 5.0,
      borderRadius: BorderRadius.circular(30.0),
      color: const Color(0xff01A0C7),
      child: FloatingActionButton.extended(
        onPressed: () async {
          if (_formKey.currentState!.validate()) {
            request.firstName = _firstNameController.text;
            request.lastName = _lastNameController.text;
            request.adress = _adressController.text;
            request.email = _emailController.text;
            request.phoneNumber = _phoneNumberController.text;
            request.username = _usernameController.text;
            request.password = _passwordController.text;
            request.passwordConfirmation = _passwordConfirmationController.text;
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
                await _userProvider.update(
                    LoggedInUser.userId!, request.toJson());
                showDialog(
                    context: context,
                    builder: (BuildContext dialogContex) => AlertDialogWidget(
                          title: "Success",
                          message: "Successfully updated profile!",
                          context: dialogContex,
                        ));
              } catch (e) {
                showDialog(
                    context: context,
                    builder: (BuildContext dialogContex) => AlertDialogWidget(
                          title: "Error",
                          message: e.toString(),
                          context: dialogContex,
                        ));
              }
            }
          }
        },
        icon: const Icon(Icons.manage_accounts_rounded),
        tooltip: 'Update your profile!',
        backgroundColor: Colors.black,
        label: const Text("Update"),
      ),
    );

    const txtSubtitle = Text("Manage your account!",
        style: TextStyle(
          fontSize: 20,
          color: Colors.white,
        ));

    return FutureBuilder(
        future: loadUserData(),
        builder: (BuildContext context, AsyncSnapshot snapshot) {
          if (snapshot.connectionState == ConnectionState.waiting) {
            return const Center(child: Text("Loading..."));
          } else if (snapshot.hasError) {
            return const Center(child: Text("An error occured!"));
          } else if (snapshot.data is UserResponse) {
            user = snapshot.data;
            _firstNameController.text = user.firstName!;
            _lastNameController.text = user.lastName!;
            _adressController.text = user.adress!;
            _emailController.text = user.email!;
            _usernameController.text = user.username!;
            _phoneNumberController.text = user.phoneNumber!;

            return Center(
                child: Container(
              height: MediaQuery.of(context).size.height,
              width: MediaQuery.of(context).size.width,
              padding: const EdgeInsets.only(left: 16, right: 16),
              decoration: const BoxDecoration(
                  image: DecorationImage(
                image: AssetImage("assets/images/registration-background.jpg"),
                fit: BoxFit.fill,
              )),
              child: ListView(
                children: [
                  Column(
                    crossAxisAlignment: CrossAxisAlignment.center,
                    mainAxisAlignment: MainAxisAlignment.center,
                    children: [
                      Form(
                        key: _formKey,
                        autovalidateMode: AutovalidateMode.onUserInteraction,
                        child: Column(
                          children: [
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
                              height: 20,
                            ),
                            btnUpdate,
                            const SizedBox(
                              height: 20,
                            ),
                          ],
                        ),
                      ),
                    ],
                  ),
                ],
              ),
            ));
          }
          return const Center(child: Text("Error"));
        });
  }
}
