import 'package:flutter/material.dart';
import 'package:flutter/src/foundation/key.dart';
import 'package:flutter/src/widgets/framework.dart';
import 'package:flutter_datetime_picker/flutter_datetime_picker.dart';
import 'package:intl/intl.dart';
import 'package:numberpicker/numberpicker.dart';
import 'package:provider/provider.dart';
import 'package:the_comfort_zone_mobile/model/appointment_type/appointment_type_response.dart';
import 'package:the_comfort_zone_mobile/model/designer/designer_response.dart';
import 'package:the_comfort_zone_mobile/providers/designer_provider.dart';

import '../../providers/appointment_provider.dart';
import '../../providers/appointment_type_provider.dart';
import '../../utils/logged_in_user.dart';
import '../../widgets/alert_dialog_widget.dart';

class AppointmentCreatePage extends StatefulWidget {
  static const String routeName = "/appointment-create";
  const AppointmentCreatePage({Key? key}) : super(key: key);

  @override
  State<AppointmentCreatePage> createState() => _AppointmentCreatePageState();
}

class _AppointmentCreatePageState extends State<AppointmentCreatePage> {
  AppointmentProvider? _appointmentProvider = null;
  AppointmentTypeProvider? _appointmentTypeProvider = null;
  DesignerProvider? _designerProvider = null;

  DateTime selectedDate = DateTime.now();
  List<DesignerResponse> designers = [];
  List<AppointmentTypeResponse> appointmentTypes = [];

  int? selectedValueDesigners;
  int? selectedValueTypes;
  int _currentDuration = 10;
  double? appointmentPrice;

  @override
  void initState() {
    _appointmentProvider = context.read<AppointmentProvider>();
    _appointmentTypeProvider = context.read<AppointmentTypeProvider>();
    _designerProvider = context.read<DesignerProvider>();
    loadDesigners();
    loadAppointmentTypes();
    super.initState();
  }

  Future loadDesigners() async {
    var apiData = await _designerProvider?.get();
    if (mounted) {
      setState(() {
        designers = apiData!;
        selectedValueDesigners = designers[0].designerId;
        appointmentPrice = designers[0].consultationPrice;
      });
    }
  }

  Future loadAppointmentTypes() async {
    var apiData = await _appointmentTypeProvider?.get();
    if (mounted) {
      setState(() {
        appointmentTypes = apiData!;
        selectedValueTypes = appointmentTypes[0].appointmentTypeId;
      });
    }
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: SingleChildScrollView(
          child: Container(
        height: MediaQuery.of(context).size.height,
        width: MediaQuery.of(context).size.width,
        padding: const EdgeInsets.only(left: 16, right: 16, top: 20),
        decoration: const BoxDecoration(
            image: DecorationImage(
          image: AssetImage("assets/images/registration-background.jpg"),
          fit: BoxFit.fill,
        )),
        child: Center(
          child: ListView(
            children: [
              const SizedBox(
                height: 20,
              ),
              txtTitle,
              const SizedBox(
                height: 80,
              ),
              TextButton(
                  onPressed: () {
                    DatePicker.showDatePicker(context,
                        showTitleActions: true,
                        minTime: DateTime.now(),
                        maxTime: DateTime(2050, 1, 1),
                        onCancel: () {}, onConfirm: (date) async {
                      selectedDate = date;
                    }, currentTime: selectedDate, locale: LocaleType.en);
                  },
                  child: const Text(
                    'Choose an appointment date (click here)',
                    style: TextStyle(color: Colors.white, fontSize: 16),
                  )),
              const SizedBox(
                height: 20,
              ),
              const Text("Designer:",
                  style: TextStyle(color: Colors.white, fontSize: 17)),
              const SizedBox(
                height: 10,
              ),
              Container(
                color: Colors.white,
                child: DropdownButtonHideUnderline(
                    child: ButtonTheme(
                  alignedDropdown: true,
                  child: DropdownButton(
                    items: _buildDesignersDropDownList(),
                    onChanged: (dynamic newValue) {
                      if (mounted) {
                        setState(() {
                          selectedValueDesigners = newValue;
                          appointmentPrice = designers
                              .firstWhere((element) =>
                                  element.designerId == selectedValueDesigners)
                              .consultationPrice;
                        });
                      }
                    },
                    value: selectedValueDesigners,
                    style: const TextStyle(
                      color: Colors.black,
                    ),
                  ),
                )),
              ),
              const SizedBox(
                height: 20,
              ),
              const Text("Appointment Type:",
                  style: TextStyle(color: Colors.white, fontSize: 17)),
              const SizedBox(
                height: 10,
              ),
              Container(
                color: Colors.white,
                child: DropdownButtonHideUnderline(
                    child: ButtonTheme(
                  alignedDropdown: true,
                  child: DropdownButton(
                    items: _buildTypesDropDownList(),
                    onChanged: (dynamic newValue) {
                      if (mounted) {
                        setState(() {
                          selectedValueTypes = newValue;
                        });
                      }
                    },
                    value: selectedValueTypes,
                    style: const TextStyle(
                      color: Colors.black,
                    ),
                  ),
                )),
              ),
              const SizedBox(
                height: 16,
              ),
              const Text("Appointment Duration (mins):",
                  style: TextStyle(color: Colors.white, fontSize: 17)),
              const SizedBox(
                height: 10,
              ),
              NumberPicker(
                textStyle: const TextStyle(color: Colors.white),
                axis: Axis.horizontal,
                value: _currentDuration,
                minValue: 10,
                maxValue: 100,
                step: 2,
                haptics: true,
                onChanged: (value) => setState(() => _currentDuration = value),
                decoration: BoxDecoration(
                  borderRadius: BorderRadius.circular(20),
                  border: Border.all(color: Colors.white),
                ),
              ),
              const SizedBox(
                height: 16,
              ),
              const Text("Total Price:",
                  textAlign: TextAlign.center,
                  style: TextStyle(color: Colors.white, fontSize: 17)),
              const SizedBox(
                height: 10,
              ),
              Text("$appointmentPrice KM",
                  textAlign: TextAlign.center,
                  style: const TextStyle(
                      color: Colors.white,
                      fontSize: 17,
                      fontWeight: FontWeight.bold)),
              const SizedBox(
                height: 20,
              ),
            ],
          ),
        ),
      )),
      floatingActionButton: FloatingActionButton.extended(
        onPressed: () async {
          Map appointment = {
            "appointmentDate":
                DateFormat('yyyy-MM-ddThh:mm').format(selectedDate),
            "duration": _currentDuration,
            "totalPrice": appointmentPrice,
            "userId": LoggedInUser.userId,
            "designerId": selectedValueDesigners,
            "appointmentTypeId": selectedValueTypes,
          };
          try {
            var response = await _appointmentProvider?.insert(appointment);
            setState(() {});
            showDialog(
                context: context,
                builder: (BuildContext dialogContex) => AlertDialogWidget(
                      title: "Message",
                      message: "Your appointment is sent successfully!",
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
        },
        icon: const Icon(Icons.edit_rounded),
        tooltip: 'Book your appointment!',
        backgroundColor: Colors.black,
        label: const Text("Book an appointment"),
      ),
      floatingActionButtonLocation: FloatingActionButtonLocation.centerFloat,
    );
  }

  final txtTitle = const Center(
      child: Text("Book an appointment",
          style: TextStyle(
              fontSize: 26, fontWeight: FontWeight.bold, color: Colors.white)));

  List<DropdownMenuItem> _buildDesignersDropDownList() {
    if (designers.isEmpty) {
      return [];
    }
    List<DropdownMenuItem> list = designers
        .map((x) => DropdownMenuItem(
              child: Text(x.name!, style: const TextStyle(color: Colors.black)),
              value: x.designerId,
            ))
        .toList();
    return list;
  }

  List<DropdownMenuItem> _buildTypesDropDownList() {
    if (appointmentTypes.isEmpty) {
      return [];
    }
    List<DropdownMenuItem> list = appointmentTypes
        .map((x) => DropdownMenuItem(
              child: Text(x.name!, style: const TextStyle(color: Colors.black)),
              value: x.appointmentTypeId,
            ))
        .toList();
    return list;
  }
}
