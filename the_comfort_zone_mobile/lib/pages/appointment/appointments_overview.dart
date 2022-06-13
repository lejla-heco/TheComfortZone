import 'package:flutter/material.dart';

class AppointmentsOverviewPage extends StatefulWidget {
  const AppointmentsOverviewPage({Key? key}) : super(key: key);

  @override
  State<AppointmentsOverviewPage> createState() => _MyWidgetState();
}

class _MyWidgetState extends State<AppointmentsOverviewPage> {
  @override
  Widget build(BuildContext context) {
    return const Scaffold(body: Center(child: Text("Appointments"),));
  }
}