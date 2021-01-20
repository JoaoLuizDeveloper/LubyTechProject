import { Component, OnInit } from '@angular/core';
import { DeveloperService } from "../../Services/developer.service";
import { IDeveloper } from '../../Models/developer.interface';
import { FormGroup, FormControl, FormBuilder, Validators } from "@angular/forms";
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-developerCreateUp-component',
  templateUrl: './developerCreateUp.component.html',
  providers: [DeveloperService]
})

export class DeveloperCreateUpComponent implements OnInit  {
    // Developer
    developer: IDeveloper = <IDeveloper>{};
    developers: IDeveloper[];
    developersCPFs: IDeveloper[];
    developersclean: IDeveloper[];    

    //Forms Variables
    formLabel: string;
    isEditMode: boolean = false;
    form: FormGroup;

  constructor(private developerService: DeveloperService, private fb: FormBuilder, private route: ActivatedRoute) {
    this.form = fb.group({
      "name": ["", Validators.required],
      "cpf": ["", Validators.required],
      "created": [""],
    });
    this.formLabel = "Create Developer";
  }

  ngOnInit() {
    this.route.params.subscribe(parametros => {
      if (parametros['id']) {
        this.developerService.getDeveloperById(parametros['id']).subscribe(response => {
          this.edit(response);
        });
      }
    });
  }

  verificarCpf($event: KeyboardEvent) {
    let cpf = (<HTMLInputElement>event.target).value;

    var strCPF = cpf.replace(".", "");
    strCPF = strCPF.replace(".", "");
    strCPF = strCPF.replace("-", "");

    var Soma;
    var Resto;
    Soma = 0;
    if (strCPF == "00000000000") {
      alert("Please set a valid CPF");
      this.form.get("cpf")!.setValue('');
      return false;
    }

    for (var i = 1; i <= 9; i++) Soma = Soma + parseInt(strCPF.substring(i - 1, i)) * (11 - i);
    Resto = (Soma * 10) % 11;

    if ((Resto == 10) || (Resto == 11)) Resto = 0;
    if (Resto != parseInt(strCPF.substring(9, 10))) {
      alert("Please set a valid CPF");
      this.form.get("cpf")!.setValue('');
      return false;
    }

    Soma = 0;
    for (var i = 1; i <= 10; i++) Soma = Soma + parseInt(strCPF.substring(i - 1, i)) * (12 - i);
    Resto = (Soma * 10) % 11;

    if ((Resto == 10) || (Resto == 11)) Resto = 0;
    if (Resto != parseInt(strCPF.substring(10, 11))) {
      alert("Please set a valid CPF");
      this.form.get("cpf")!.setValue('');
      return false;
    }

    var developer = this.developerService.getsearchCpf(parseInt(strCPF)).subscribe(
      response => this.developersCPFs = response
    )

    if (this.developersCPFs.length > 0) {
      alert("This number of CPF already exist");
      this.form.get("cpf")!.setValue('');
      this.developersCPFs = this.developersclean;
      return false;
    }

    return true;
  }

  onSubmit() {
    this.developer.name = this.form.controls["name"].value;
    this.developer.cpf = this.form.controls["cpf"].value;

    //Create and Update
    if (this.isEditMode) {      
      this.developer.created = this.form.controls["created"].value;
      this.developerService.updateDeveloper(this.developer)
        .subscribe(response => {
          alert("The Developer has been updated");
          this.form.reset();
          this.formLabel = "Create Developer";
        });
    } else {
      this.developer.created = new Date();
      this.developerService.saveDeveloper(this.developer)
        .subscribe(response => {
          alert("The Developer has been created");
          this.form.reset();
          this.formLabel = "Create Developer";
        });
    }
  };
  
  // copy the Developer to be updated
  edit(developerForm: IDeveloper) {
    this.formLabel = "Update Product";
    this.isEditMode = true;
    this.developer = developerForm;
    this.form.get("name")!.setValue(developerForm.name);
    this.form.get("cpf")!.setValue(developerForm.cpf);
    this.form.get("created")!.setValue(developerForm.created);
  }

  cancel() {
    this.developer = <IDeveloper>{};
    this.form.get("name")!.setValue('');
    this.form.get("cpf")!.setValue('');
  };
}
