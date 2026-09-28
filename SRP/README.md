### WardBoard
 المشكلة في  الكلاس الكلاس يجمع بين 5 مسؤوليات مختلفة تماماً

إدارة الأسرّة والمرضى (Bed & Patient State Management): تخزين من في السرير وو ربط المرضى بالأسرّة

قواعد الحساب الإكلينيكي (Clinical Scoring / Acuity Rules): منطق حساب خطورة المريض (ScoreAcuity). هذا منطق طبي قد تتغير معاييره مستقلاً تماماً عن إدارة الأسرّة

نظام التنبيهات والإنذارات (Paging & Alerting): منطق متى يتم إطلاق إنذار CODE-YELLOW وتخزينه في _pagerLog. لو تغيرت سياسة المستشفى في الإنذارات، ستضطر لتعديل هذا الكلاس

تنسيق ملاحظات التسليم بين التمريض (Handoff Notes Generation): طريقة صياغة وتنسيق رسالة BuildHandoffNote. شكل التقرير قد يتغير بناءً على طلب التمريض بغض النظر عن القواعد الطبية

تصدير البيانات (Export/Persistence): دالة ExportCensusCsv لتصدير البيانات بصيغة CSV. لو أرادوا التصدير بصيغة JSON أو Excel مستقبلاً، ستضطر لتعديل الكلاس

---

### CheckoutBasket:
إدارة بنود السلة (Cart Items Management): تخزين وإضافة المنتجات (_lines و AddLine).

منطق الخصومات وقسائم الشراء (Coupon Parsing & Discount Rules): تحليل النصوص الترويجية (_couponRaw وحساب قيمة الخصم في DiscountAmount). هذا منطق تسويقي يتغير مستقلاً عن الحسابات.

سياسة التغليف ورسوم الهدايا (Gift Wrap & Packaging Policy): تحديد رسوم التغليف (_giftWrap). هذا يتغير لو تغيرت سياسة تسعير الهدايا.

صياغة رسالة الهدية (Gift Message Copy): تنسيق رسالة البطاقة للعميل (GiftMessageCard). هذا نص تسويقي يتغير بناءً على رغبة التسويق.

محاكاة بوابة الدفع (Payment Authorization Stub): توليد كود المصادقة (AuthorizePaymentStub). هذا جزء يتعلق ببوابة الدفع ويتغير تماماً عن حسابات السلة.

---
### SupportTicket:
إدارة حالة التذكرة (Ticket State Management): تخزين البيانات الأساسية (الهوية، الموضوع، المحتوى، ووقت الفتح).

منطق تحليل النص وتحديد الأولويات (Priority Evaluation / Heuristics): قراءة الكلمات المفتاحية لتحديد ما إذا كانت الأولوية P1 أو P2 أو P3. (سبب تغيير: تعديل سياسات وقواعد الدعم الفني).

حسابات اتفاقية مستوى الخدمة (SLA Calculation): حساب المواعيد النهائية وإذا ما كانت التذكرة قد تجاوزت الوقت المسموح (SlaDeadline و IsBreached). (سبب تغيير: تعديل سياسات الـ SLA التشغيلية).

صياغة الردود العامة (Public Reply Templates): صياغة النصوص والرسائل الموجهة للعملاء. (سبب تغيير: تعديل نبرة الخطاب أو قوالب خدمة العملاء).

تنسيق تنبيهات التصعيد الداخلي (Internal Escalation Blurb): بناء رسالة التصعيد الداخلية للفرق التقنية.

---
### LoanDesk:
إدارة بيانات القرض (Loan State / Properties): تخزين البيانات الأساسية (المبلغ المطلوب، درجة الائتمان، شهور العمل، وجود ضمان).

نموذج حساب المخاطر والأهلية (Risk Scoring & Eligibility Logic): حساب درجة المخاطر وتحديد ما إذا كان العميل مؤهلاً (RiskScore و IsEligible). (سبب تغيير: تعديل سياسات لجنة المخاطر).

قائمة المستندات المطلوبة (Required Documents Checklist): تحديد الأوراق الرسمية المطلوبة بناءً على المبلغ والضمان (RequiredDocuments). (سبب تغيير: تعديل اللوائح التنظيمية وقوانين الامتثال).

صياغة رسائل القرار (Decision Letter Prose): تنسيق كتابة رسائل الموافقة أو الرفض للعميل (DecisionLetter). (سبب تغيير: تعديل الصياغات القانونية أو التسويقية للتواصل).

تصدير بيانات المكتبيين/التحليلات (Underwriter Analytics Export): بناء سطر البيانات للـ CSV (UnderwriterCsvRow). (سبب تغيير: تعديل شكل تقارير التحليلات).

---

### CourseEnrollmentDesk:
إدارة المقاعد وقائمة الانتظار (Seating & Waitlist Management): تخزين الطلاب المسجلين وقائمة الانتظار، ومنطق التسجيل والترقية (Register و PromoteFromWaitlist و WaitlistPosition). (سبب تغيير: تعديل سياسات وقواعد التسجيل).

صياغة حزمة الترحيب (Welcome Packet Markdown): تصميم وتنسيق محتوى رسالة الترحيب للطلاب (WelcomePacketMarkdown). (سبب تغيير: تعديل نصوص والتسويق الأكاديمي).

حساب وتنسيق الفواتير (Tuition Invoice Line): حساب الضرائب (VAT) وتنسيق سطر الفاتورة المالية للطلاب (TuitionInvoiceLine). (سبب تغيير: تعديل القوانين المالية أو ضرائب الأكاديمية).

---
### KitchenTicket:
إدارة بنود المطبخ (Kitchen Items State): تخزين الأطباق ومكوناتها وأوقات التحضير الخاصة بها.

فحص مسببات الحساسية (Allergen Detection): البحث في المكونات لاكتشاف الأكل الذي يسبب الحساسية مثل منتجات الألبان، الجلووتين، المكسرات، والمأكولات البحرية (DetectAllergens). (سبب تغيير: تعديل اللوائح التنظيمية الصحية).

حساب وقت التحضير التوقعي (ETA Heuristics): حساب الوقت المتوقع لتجهيز الطلب بناءً على المحطات المفتوحة ومدة التحضير (EstimatedReadyMinutes). (سبب تغيير: تعديل نماذج تشغيل المطبخ).

تنسيق الطباعة الحرارية (Thermal Ticket Layout): تنسيق شكل تذكرة الطابعة الحرارية (RenderThermalTicket). (سبب تغيير: تغيير نوع أو مواصفات طابعة المطبخ).

تحديد مسار العرض والتسريع (Expo Lane Hint): تحديد اللان المناسب للطلب (ExpoLaneHint).

---

### SubscriptionBilling:
إدارة بيانات وقيم الاشتراك (Subscription State & Proration Math): تخزين معرف العميل، السعر الشهري، التواريخ، وحساب الحصص النسبية (Prorate). (سبب تغيير: تعديل التقويم المالي وقواعد المحاسبة).

توليد أرقام الفواتير (Invoice Number Minting): إصدار أرقام الفواتير بتسلسل زمني (NextInvoiceNumber). (سبب تغيير: تعديل نظام ترقيم الفواتير والسياسات الضريبية).

تتبع مدفوعات الفشل وصياغة رسائل التحصيل (Dunning Email & Failed Payments): تسجيل حالات الفشل وصياغة الإشعارات والمطالب المالية للعملاء (DunningEmail). (سبب تغيير: تعديل سياسات التحصيل ونبرة خدمة العملاء).

تصدير قيود الدفتر اليومي (Ledger Journal Line): بناء سطر سجل القيود المحاسبية (LedgerJournalLine). (سبب تغيير: تعديل صيغة تقارير الحسابات العامة).

---
### WarehousePickList:
إدارة بنود المستودع وحالة المخزون (Inventory Items State): تخزين المنتجات، الممرات، الأرفف، والكميات المطلوبة والمتاحة (AddNeed).

منطق تخصيص المخزون وتحديد العجز (Stock Allocation Logic): حساب الكميات المتاحة للتخصيص ومقارنتها بالمطلوب (Allocate). (سبب تغيير: تعديل سياسات وحسابات تخصيص المخزون).

خوارزمية ترتيب المشي في المستودع (Warehouse Walking Path): ترتيب المنتجات حسب الممرات والأرفف لتقليل وقت حركة العامل (WalkingOrder). (سبب تغيير: تعديل تصميم أو تخطيط المستودع).

صياغة تعليمات جهاز الالتقاط (Picker Script / UX Wording): تكوين النصوص والخطوات المعروضة على جهاز الـ Handheld الخاص بالعامل والتنبيهات (PickerScript). (سبب تغيير: تعديل واجهة استخدام أجهزة العمال).

تصدير بيانات التكامل مع نظام إدارة المستودعات (WMS XML Export): بناء رسالة الـ XML المخصصة للربط مع أنظمة الـ WMS (WmsXmlBatch). (سبب تغيير: تعديل مواصفات عقد التكامل مع النظام الخارجي).

---
### GradeBook:
إدارة درجات الطلاب وحساب المتوسطات (Scores Storage & Average Calculation): تخزين درجات كل طالب وحساب المتوسط الحسابي (Record و Average). (سبب تغيير: تعديل طريقة تخزين أو حساب الدرجات).

سياسة تقديرات الحروف واللوائح الأكاديمية (Letter Bands & Honor Roll Policy): تحديد التقدير الحرفي (A, B, C...) وشروط شرف اللوحة (Letter و MeetsHonorRoll). (سبب تغيير: تعديل سياسات شؤون الطلاب ولوائح الجامعة).

تنسيق كشف السجل الأكاديمي (Transcript Plain Text): صياغة النص المطبوع لسجل الدرجات الرسمي (TranscriptPlain). (سبب تغيير: تعديل شكل ونماذج السجلات الرسمية).

تصدير درجات الطلاب بصيغة CSV (CSV Data Export): بناء وتصدير تقرير الـ CSV للدرجات (ExportCsv). (سبب تغيير: تعديل صيغة وتنسيق التقارير المصدرة).

---
### AppointmentDesk:
قواعد أوقات العمل وحجز المواعيد (Business Hours & Booking State): إدارة المهل الزمنية، أوقات الفتح والغلّق، الفترات المتاحة، والتحقق من مواعيد العمل وحجز المواعيد (IsWithinBusinessHours, FindNextSlot, TryBook). (سبب تغيير: تعديل سياسات العمل والعيادة).

توليد ملفات التقويم بصيغة ICS (Calendar ICS Serialization): بناء نص الـ ICS المتوافق مع برامج التقويم الخارجية (ToIcs). (سبب تغيير: تعديل مواصفات ومعايير ملفات الـ ICS).

صياغة رسائل التذكير القصيرة (SMS Reminder Formatting): تنسيق رسائل التذكير النصية للمرضى (SmsReminder). (سبب تغيير: تعديل قوالب وتنسيق الرسائل النصية).
---

# SRP Lab — Responsibilities Identification (Task 1.1)

## 1. WardBoard
* **Responsibilities:**
  1. Managing bed and patient states.
  2. Calculating clinical acuity scores based on vitals (`ScoreAcuity`).
  3. Managing and logging operational alert triggers/pagers (`DrainPagerLog`).
  4. Building and formatting nurse handoff text notes (`BuildHandoffNote`).
  5. Exporting census data into CSV format (`ExportCensusCsv`).
* **Why it's a problem:** Clinical scoring rules, alert policies, nursing report layouts, and export persistence formats all change for completely different business reasons. Mixing them makes the class brittle and hard to unit-test in isolation.




## 2. CheckoutBasket
* **Responsibilities:**
  1. Managing cart items and quantities.
  2. Parsing marketing coupon strings and calculating discounts (`DiscountAmount`).
  3. Handling gift-wrap packaging fees (`EnableGiftWrap`).
  4. Formatting customer-facing gift message cards (`GiftMessageCard`).
  5. Simulating payment authorization hashes (`AuthorizePaymentStub`).
* **Why it's a problem:** Marketing rules (coupons, gift messages), pricing policies, and payment gateway stubs are owned by different teams. A change in marketing discount syntax or payment encryption formats should never require modifying shopping cart math.



## 3. SupportTicket
* **Responsibilities:**
  1. Managing ticket core state (ID, subject, body, timestamps).
  2. Evaluating text heuristics to determine priority levels (`RecalculatePriorityFromText`).
  3. Calculating operational SLA deadlines and breach checks (`SlaDeadline`, `IsBreached`).
  4. Drafting public customer reply templates (`DraftPublicReply`).
  5. Formatting internal escalation blurbs (`InternalEscalationBlurb`).
* **Why it's a problem:** Text keyword heuristics and SLA policy timelines change independently of customer service phrasing and communication tones. Coupling them creates tight dependencies across separate business domains.


## 4. LoanDesk
* **Responsibilities:**
  1. Holding loan application parameters (amount, credit score, etc.).
  2. Executing risk scoring models and eligibility rules (`RiskScore`, `IsEligible`).
  3. Generating required document compliance checklists (`RequiredDocuments`).
  4. Drafting legal/commercial decision letters (`DecisionLetter`).
  5. Exporting analytics/underwriter CSV rows (`UnderwriterCsvRow`).
* **Why it's a problem:** Risk committee formulas, compliance regulations, legal correspondence templates, and analytics schemas all evolve at different paces and involve entirely different stakeholders.



## 5. CourseEnrollmentDesk
* **Responsibilities:**
  1. Managing seating capacity, course codes, and tuition pricing.
  2. Handling student registrations, seat assignments, and waitlist queues (`Register`, `PromoteFromWaitlist`).
  3. Building markdown-formatted academic welcome packets (`WelcomePacketMarkdown`).
  4. Formatting tuition invoice lines and tax calculations (`TuitionInvoiceLine`).
* **Why it's a problem:** Seat capacity and waitlist logistics have nothing to do with marketing welcome texts or financial tax/invoice formatting. Changing invoice formatting shouldn't risk breaking student seat registration logic.



## 6. KitchenTicket
* **Responsibilities:**
  1. Storing ordered items, ingredients, and prep times.
  2. Scanning ingredients for allergens (`DetectAllergens`).
  3. Calculating kitchen station ETA heuristics (`EstimatedReadyMinutes`).
  4. Rendering thermal ticket physical print layouts (`RenderThermalTicket`).
  5. Determining expo lane routing hints (`ExpoLaneHint`).
* **Why it's a problem:** Allergen regulatory dictionaries, kitchen operational capacity models, and hardware receipt printer specifications all change independently.



## 7. SubscriptionBilling

* **Responsibilities:**
  1. Managing subscription periods, monthly pricing, and failed payment counts.
  2. Calculating proration math based on calendars (`Prorate`).
  3. Minting sequential invoice numbers (`NextInvoiceNumber`).
  4. Drafting dunning and collection email notices (`DunningEmail`).
  5. Exporting accounting ledger journal lines (`LedgerJournalLine`).
* **Why it's a problem:** Fiscal calendar math, invoice numbering policies, collections tone copy, and accounting export schemas are completely distinct operational domains.



## 8. WarehousePickList
* **Responsibilities:**
  1. Storing inventory item needs, aisles, bins, and on-hand quantities.
  2. Allocating stock and identifying shortages (`Allocate`).
  3. Planning warehouse walking path heuristics (`WalkingOrder`).
  4. Formatting handheld picker script steps and warning notices (`PickerScript`).
  5. Generating WMS integration XML batches (`WmsXmlBatch`).
* **Why it's a problem:** Warehouse layout optimizations, allocation backorder rules, handheld UI scripts, and third-party WMS XML integration contracts all have separate reasons to change.


## 9. GradeBook
* **Responsibilities:**
  1. Storing student test scores and calculating averages (`Record`, `Average`).
  2. Enforcing academic letter-band and honor roll policies (`Letter`, `MeetsHonorRoll`).
  3. Formatting plain-text registrar transcripts (`TranscriptPlain`).
  4. Exporting summary scores into CSV format (`ExportCsv`).
* **Why it's a problem:** Faculty senate grading policies change independently of registrar document text formats or data export CSV schemas.


## 10. AppointmentDesk
* **Responsibilities:**
  1. Managing clinic operating hours, slot intervals, and booking states (`IsWithinBusinessHours`, `TryBook`).
  2. Searching for available slots (`FindNextSlot`).
  3. Generating calendar `.ics` blobs (`ToIcs`).
  4. Formatting SMS reminder messages (`SmsReminder`).
* **Why it's a problem:** Clinic HR/operations hours policies are completely separate from calendar file interoperability standards or SMS text message marketing/notification copy.