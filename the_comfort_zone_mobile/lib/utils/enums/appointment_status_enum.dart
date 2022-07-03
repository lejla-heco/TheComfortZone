enum AppointmentStatus {
  accepted,
  declined,
}

extension ParseToString on AppointmentStatus {
  String toShortString() {
    return toString().split('.').last;
  }
}