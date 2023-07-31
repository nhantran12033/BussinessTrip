import { ListService } from '@abp/ng.core';
import { HttpClient } from '@angular/common/http';
import { Component, OnInit, ViewChild, ElementRef, Renderer2, NgModule } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormArray, FormControl, Form } from '@angular/forms';
import { TripInformationService } from '../proxy/trips';
import { ToasterService } from "@abp/ng.theme.shared";
import { NgbDateNativeAdapter, NgbDateAdapter } from '@ng-bootstrap/ng-bootstrap';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-trip',
  templateUrl: './trip.component.html',
  styleUrls: ['./trip.component.scss'],

  providers: [
    ListService,
    { provide: NgbDateAdapter, useClass: NgbDateNativeAdapter }],

})
export class TripComponent implements OnInit {
  isEdit: boolean = false;
  editdata: any;
  editCode: any;
  expense: any
  depart: any
  data: any
  currency: any
  formDetail: FormGroup;
  type = ["DOMESTIC", "OVERSEA"]
  user = ["nhantran12033@gmail.com"]
  html: string[] = [];
  newtrip: string[] = [];
  Unit: any;
  Volume: any;
  currentID: string;
  selectedCode: string;
  selectedExchangeRates: any[] = [];
  total: number
  tripIndex: number;
  constructor(
    public readonly list: ListService,
    private trip: TripInformationService,
    private http: HttpClient,
    private fb: FormBuilder,
    private toastr: ToasterService,
    private route: ActivatedRoute,
    private router: Router,

  ) { }
  ngOnInit() {
    this.loadCurrency();
    this.loadDepartment();
    this.loadExpense();
    this.loadLegal();
    this.Edit();
  }
  formNewTrip !: FormArray<any>;
  formNewDetailTrip !: FormGroup<any>;
  loadLegal() {
    this.http.get("https://localhost:44344/api/app/legal-entity/legal").subscribe((result) => {
      this.data = result;
    })
  }
  loadDepartment() {
    this.http.get("https://localhost:44344/api/app/department").subscribe((result) => {
      this.depart = result;
    })
  }
  loadExpense() {
    this.http.get("https://localhost:44344/api/app/expense-code").subscribe((result) => {
      this.expense = result;
    })
  }
  loadCurrency() {
    this.http.get("https://localhost:44344/api/app/currency").subscribe((result) => {
      this.currency = result;
    })
  }
  
    form = this.fb.group({
      operaterName: this.fb.control(''),
      requestNumber: this.fb.control(''),
      requestedDate: this.fb.control(null),
      businessType: this.fb.control(''),
      legalEntity: this.fb.control(''),
      department: this.fb.control(''),
      expenseCode: this.fb.control(''),
      verifierUsername: this.fb.control(''),
      verifierName: this.fb.control(''),
      notes: this.fb.control(''),
      totalAmount: this.fb.control({ value: 0, disabled: true }),
      tripExpenseDetail: this.fb.array([this.FormDetail()])
    });
  
  FormDetail() {
    return this.fb.group({
      purpose: this.fb.control(''),
      destination: this.fb.control(''),
      checkinTime: this.fb.control(null),
      checkoutTime: this.fb.control(null),
      totalNights: this.fb.control(0),
      item: this.fb.control(''),
      specification: this.fb.control(''),
      originalCurrency: this.fb.control(''),
      equivalentInVND: this.fb.control({ value: 0, disabled:true }),
      notes: this.fb.control(''),
      originalUnit: this.fb.control(0),
      volume: this.fb.control(0),
      originalAmount: this.fb.control({value: 0, disabled: true})
    });
  }
  AddNewTrip() {
    this.formNewTrip = this.form.get("tripExpenseDetail") as FormArray;
    this.formNewTrip.push(this.FormDetail());
  }
  
  get tripExpenseDetail() {
    return this.form.get("tripExpenseDetail") as FormArray;
  }
  RemoveNewTrip(index: any) {
    this.formNewTrip = this.form.get("tripExpenseDetail") as FormArray;
    this.formNewTrip.removeAt(index)
  }
  clickMess() {
    this.toastr.success('Thông báo thành công', 'Đã đưa dữ liệu vào cơ sở dữ liệu');
  }
  save() {
    if (this.form.valid) {
      this.trip.createTripInformation(this.form.getRawValue()).subscribe(res => {
        this.toastr.success('Thông báo thành công', 'Đã thêm dữ liệu');
        this.form.reset();
      });
    }
  }
  onSubmit() {
    if (this.isEdit == false) {
      this.save();
    }
    else {
      this.SaveEdit();
    }
  }
  Edit() {
    this.editCode = this.route.snapshot.paramMap.get('id');
    if (this.editCode != null) {
      this.trip.getListID(this.editCode).subscribe(item => {
        this.editdata = item;
        if (this.editdata.TripExpenseDetail != null) {
          for (let i = 0; i < this.editdata.TripExpenseDetail.length - 1; i++) {
            this.AddNewTrip();
          }
        }
        this.form.patchValue(this.editdata);
        this.isEdit = true;
      })
    }
  }
  SaveEdit() {
    if (this.form.valid) {
      this.trip.updateList(this.editCode, this.form.getRawValue()).subscribe(res => {
        this.toastr.success('Thông báo thành công', 'Cập nhật dữ liệu');
        this.router.navigateByUrl('/businessTrip');
      });
    }
  }
  onSelectCode(index: any, code: string) {
    const selectedRecord = this.currency.find(record => record.code === code);
    if (selectedRecord) {
      const formNewTrip = this.form.get("tripExpenseDetail") as FormArray;
      const formNewDetailTrip = formNewTrip.at(index) as FormGroup;
      this.selectedExchangeRates[index] = selectedRecord.exchangeRate;
      this.calculateTotalAmount(index);
    }
  }
  calculateTotalAmount(index:any) {
    this.formNewTrip = this.form.get("tripExpenseDetail") as FormArray;
    this.formNewDetailTrip = this.formNewTrip.at(index) as FormGroup;
    let Unit = this.formNewDetailTrip.get('originalUnit')?.value;
    let Volume = this.formNewDetailTrip.get('volume').value;
    let amount = Unit * Volume
    this.formNewDetailTrip.get('originalAmount').setValue(amount);
    this.formNewDetailTrip.get('equivalentInVND').setValue(Unit * Volume * this.selectedExchangeRates[index]);
    this.sumTotal();
  }
  sumTotal() {
    let array = this.form.getRawValue().tripExpenseDetail;
    let sum = 0;
    array.forEach((x: any) => {
      sum = sum + x.equivalentInVND;
    });
    this.form.get("totalAmount").setValue(sum);
  }
}
