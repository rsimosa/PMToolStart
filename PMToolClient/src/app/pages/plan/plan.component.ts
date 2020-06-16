import { Component, OnInit } from '@angular/core';
import { PlanningService } from 'src/app/services/planning.service';
import { Project } from 'src/app/dtos/Project';

@Component({
  selector: 'app-plan',
  templateUrl: './plan.component.html',
  styleUrls: ['./plan.component.scss']
})
export class PlanComponent implements OnInit {

  public columnName: Array<string>;
  public projectData: Array<any> = [];
  public projectObject: Project;
  constructor(private planningService: PlanningService) {
    this.columnName = ['Id', 'Task Name', 'Estimate', 'Predecessors', 'Resource', 'Priority', 'Start', 'Finish'];
    planningService.getProject().then(project => {
      this.projectObject = project;
    });
  }

  async saveProject() {
    alert("Saved");
    this.planningService.saveProject(this.projectObject);
  }

  async addActivity() {
    alert("add row");
    this.projectObject.activities.push({
      id: 2,
      taskName: 'Setup DB2',
      start: new Date(),
      finish: new Date(),
      estimate: 2.0,
      predecessor: 1,
      resource: 'test',
      priority: 500
    });
  }

  async getProject() {
    this.projectObject = await this.planningService.getProject();
  }

  ngOnInit(): void {
  }

}

//this is where the data lives, its going to be bound to. planning service is going to load the data
