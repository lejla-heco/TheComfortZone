import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:flutter_datetime_picker/flutter_datetime_picker.dart';
import 'package:intl/intl.dart';
import 'package:provider/provider.dart';
import 'package:the_comfort_zone_mobile/model/appointment/appointment_response.dart';
import 'package:the_comfort_zone_mobile/providers/appointment_provider.dart';

import '../../utils/enums/appointment_status_enum.dart';
import '../../widgets/alert_dialog_widget.dart';

class AppointmentsOverviewPage extends StatefulWidget {
  const AppointmentsOverviewPage({Key? key}) : super(key: key);

  @override
  State<AppointmentsOverviewPage> createState() => _MyWidgetState();
}

class _MyWidgetState extends State<AppointmentsOverviewPage> {
  ScrollController? _scrollController;

  AppointmentProvider? _appointmentProvider = null;
  List<AppointmentResponse> data = [];
  var formatter = NumberFormat('###.0#');

  @override
  void initState() {
    _scrollController = ScrollController();
    _appointmentProvider = context.read<AppointmentProvider>();
    loadData(null);
    super.initState();
  }

  Future loadData(DateTime? appointmentDate) async {
    Map<String, String>? searchRequest = appointmentDate == null
        ? null
        : {
            "appointmentDate": appointmentDate.toString(),
          };

    var apiData =
        await _appointmentProvider?.getAppointmentsByUserId(searchRequest);
    if (mounted) {
      setState(() {
        data = apiData!;
      });
    }
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: SafeArea(
        child: CupertinoScrollbar(
          thumbVisibility: true,
          thickness: 5,
          controller: _scrollController,
          child: ListView(
            controller: _scrollController,
            children: [
              Column(
                children: [
                  Stack(alignment: Alignment.center, children: [
                    Container(
                        height: 200,
                        decoration: const BoxDecoration(
                            image: DecorationImage(
                          image: AssetImage("assets/images/consultation-bg.png"),
                          fit: BoxFit.fill,
                        ))),
                    const Center(
                        child: Text("My Design Consultations",
                            style: TextStyle(
                                color: Colors.white,
                                fontSize: 25,
                                fontWeight: FontWeight.bold)))
                  ]),
                  const SizedBox(
                    height: 10,
                  ),
                ],
              ),
              TextButton(
                  onPressed: () {
                    DatePicker.showDatePicker(context,
                        showTitleActions: true,
                        minTime: DateTime(2000, 1, 1),
                        maxTime: DateTime(2050, 1, 1), onCancel: () {
                      showDialog(
                          context: context,
                          builder: (BuildContext dialogContex) => AlertDialog(
                                title: const Text("Question"),
                                content: const Text(
                                    "Do you want to realod appointment data?"),
                                actions: [
                                  TextButton(
                                      onPressed: () async {
                                        Navigator.pop(dialogContex);
                                        await loadData(null);
                                      },
                                      child: const Text("Yes")),
                                  TextButton(
                                    onPressed: () =>
                                        Navigator.pop(dialogContex),
                                    child: const Text("No"),
                                  )
                                ],
                              ));
                    }, onConfirm: (date) async {
                      try {
                        var apiData = await loadData(date);
                        setState(() {
                          data = apiData;
                        });
                      } catch (e) {showDialog(
                              context: context,
                              builder: (BuildContext dialogContex) =>
                                  AlertDialogWidget(
                                    title: "Error",
                                    message: "An error occured!",
                                    context: dialogContex,
                                  ));
                      }
                    }, currentTime: DateTime.now(), locale: LocaleType.en);
                  },
                  child: const Text(
                    'Show date time picker (click here)',
                    style: TextStyle(color: Colors.blue),
                  )),
              Column(
                crossAxisAlignment: CrossAxisAlignment.start,
                children: _buildAppointmentCards(),
              )
            ],
          ),
        ),
      ),
    );
  }

  List<Widget> _buildAppointmentCards() {
    if (data.isEmpty) {
      return [
        const Center(
            child: Text(
          "No data",
          style: TextStyle(
              color: Colors.grey, fontSize: 25, fontWeight: FontWeight.bold),
        )),
      ];
    }

    List<Column> list = data
        .map((x) => Column(
              children: [
                Container(
                    padding: const EdgeInsets.all(8),
                    decoration: BoxDecoration(color: Colors.grey.shade200),
                    width: MediaQuery.of(context).size.width,
                    child: Column(
                      crossAxisAlignment: CrossAxisAlignment.start,
                      children: [
                        Text("Consultation number: ${x.appointmentNumber}",
                            style: const TextStyle(
                                color: Colors.black,
                                fontSize: 17,
                                fontWeight: FontWeight.bold)),
                        Text(
                            "Consultation date: ${DateFormat.yMMMEd().format(x.appointmentDate!)}",
                            style: const TextStyle(
                                color: Colors.black, fontSize: 15)),
                        Text("Designer expert: ${x.designerName}",
                            style: const TextStyle(
                                color: Colors.black, fontSize: 15)),
                        Text("Appointment type: ${x.type}",
                            style: const TextStyle(
                                color: Colors.black, fontSize: 15)),
                        Text("Appointment duration: ${x.duration} min",
                            style: const TextStyle(
                                color: Colors.black, fontSize: 15)),
                        Text(
                            "Consultation status: ${x.approved == null ? AppointmentStatus.declined.toShortString().toUpperCase() : x.approved == true ? AppointmentStatus.accepted.toShortString().toUpperCase() : AppointmentStatus.declined.toShortString().toUpperCase()}",
                            style: const TextStyle(
                                color: Colors.black, fontSize: 15)),
                        Align(
                          alignment: Alignment.bottomRight,
                          child: Text(
                            "Total price: ${formatter.format(x.totalPrice)} KM",
                            style: const TextStyle(
                                color: Colors.black,
                                fontSize: 16,
                                fontWeight: FontWeight.bold),
                          ),
                        ),
                      ],
                    )),
                const SizedBox(
                  height: 10,
                )
              ],
            ))
        .toList();
    return list;
  }
}
