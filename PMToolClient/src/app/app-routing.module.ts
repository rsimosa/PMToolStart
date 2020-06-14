import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { TestComponent } from './pages/test/test.component';
import { PlanComponent } from './pages/plan/plan.component';


const routes: Routes = [
  { path: 'test', component: TestComponent},
  { path: 'plan', component: PlanComponent},
  { path: '**', redirectTo: '/plan'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
